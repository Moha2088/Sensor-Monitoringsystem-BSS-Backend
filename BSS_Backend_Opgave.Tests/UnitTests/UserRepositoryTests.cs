using AutoMapper;
using BSS_Backend_Opgave.Models;
using BSS_Backend_Opgave.Repositories.Data;
using BSS_Backend_Opgave.Repositories.Models.Dtos.UserDtos;
using BSS_Backend_Opgave.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BSS_Backend_Opgave.Tests.UnitTests;

public class UserRepositoryTests
{
    private readonly BSS_Backend_OpgaveAPIContext _context;
    private readonly IMapper _mapper;
    private readonly UserRepository _userRepository;

    public UserRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<BSS_Backend_OpgaveAPIContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

        _context = new BSS_Backend_OpgaveAPIContext(options);

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<UserCreateDTO, User>();
            cfg.CreateMap<User, UserGetDto>();
        });
        _mapper = config.CreateMapper();

        _userRepository = new UserRepository(_context, _mapper);
    }


    [Fact]
    public async Task GetUser_ShouldReturnUserGetDto_WhenUserExists()
    {
        var cancellationToken = new CancellationToken();
        
        var dto = new UserCreateDTO
        {
            Name = "John",
            Password = "Doe123",
            Email = "johndoe1@example.com"
        };

        var user = _mapper.Map<User>(dto);
        _context.User.Add(user);
        await _context.SaveChangesAsync(cancellationToken);

        var result = await _userRepository.GetUser(user.Id, cancellationToken);

        Assert.NotNull(result);
        Assert.Equal(user.Id, result.Id);
        Assert.IsType<UserGetDto>(result);
    }

    [Fact]
    public async Task GetUsers_ShouldReturnCollectionOfUserGetDtos_WhenUsersExist()
    {
        var cancellationToken = new CancellationToken();

        var dtos = new List<UserCreateDTO>
        {
            new UserCreateDTO { Name = "John", Email = "johndoe@example.com", Password = "Doe123" },
            new UserCreateDTO { Name = "Jane", Email = "janedoe@example.com", Password = "Doe456" },
            new UserCreateDTO { Name = "Mark", Email = "markdoe@example.com", Password = "Doe789" }
        };

        var users = _mapper.Map<IEnumerable<User>>(dtos);

        _context.User.AddRange(users!);
        await _context.SaveChangesAsync(cancellationToken);

        var result = await _userRepository.GetUsers(cancellationToken);

        Assert.NotNull(result);
        Assert.IsType<List<UserGetDto>>(result);
        result.ToList().ForEach(user => Assert.IsType<UserGetDto>(user));
    }

    [Fact]
    public async Task CreateUser_ShouldReturnUserGetDto_WhenDtoIsValid()
    {
        var cancellationToken = new CancellationToken();
        var organisation = new Organisation
        {
            Name = "Organisation"
        };

        _context.Organisation.Add(organisation);

        await _context.SaveChangesAsync(cancellationToken);

        var dto = new UserCreateDTO
        {
            Name = "JohnJohn",
            Email = "johndoe123@example.com",
            Password = "Doe123"
        };

        var expectedName = dto.Name;
        var expectedEmail = dto.Email;
        var expectedPassword = dto.Password;
        
        var result = await _userRepository.CreateUser(dto, organisation.Id, cancellationToken);


        Assert.NotNull(result);
        Assert.IsType<UserGetDto>(result);
        Assert.Equal(result.Name, expectedName);
        Assert.Equal(result.Email, expectedEmail);
    }

    [Fact]
    public async Task CreateUser_ShouldThrowInvalidOperationException_WhenEmailExists()
    {
        var cancellationToken = new CancellationToken();

        var organisation = new Organisation
        {
            Name = "Organisation"
        };

        var existingUserDto = new UserCreateDTO
        {
            Name = "JohnDoe123",
            Email = "JohnDoe@1236.com",
            Password = "JohnDoe12345"
        };

        var existingUser = _mapper.Map<User>(existingUserDto);
        _context.User.Add(existingUser);
        _context.Organisation.Add(organisation);
        await _context.SaveChangesAsync(cancellationToken);

        var userDto = new UserCreateDTO
        {
            Name = "JohnDoe456",
            Email = "JohnDoe@1236.com",
            Password = "JohnDoe678910"
        };

        Func<Task> CreateUserAction = async () => await _userRepository.CreateUser(userDto, organisation.Id, cancellationToken);
        
        await Assert.ThrowsAsync<InvalidOperationException>(CreateUserAction);


    }
}