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
            Email = "johndoe@example.com"
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

        var dto = new UserCreateDTO
        {
            Name = "JohnJohn",
            Email = "johndoe@example.com",
            Password = "Doe123"
        };

        var expectedName = dto.Name;
        var expectedEmail = dto.Email;
        var expectedPassword = dto.Password;


        var user = _mapper.Map<User>(dto);
        _context.User.Add(user);
        await _context.SaveChangesAsync(cancellationToken);

        var result = await _userRepository.CreateUser(dto, cancellationToken);


        Assert.NotNull(result);
        Assert.IsType<UserGetDto>(result);
        Assert.Equal(result.Name, expectedName);
        Assert.Equal(result.Email, expectedEmail);
        Assert.Equal(result.Password, expectedPassword);
    }
}