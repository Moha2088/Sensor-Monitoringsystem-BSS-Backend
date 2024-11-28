using AutoMapper;
using BSS_Backend_Opgave.Models;
using BSS_Backend_Opgave.Repositories.Data;
using BSS_Backend_Opgave.Repositories.Models.Dtos.SensorDtos;
using BSS_Backend_Opgave.Repositories.Models.Dtos.UserDtos;
using BSS_Backend_Opgave.Repositories.Repository;
using BSS_Backend_Opgave.Tests.UnitTests.Fixtures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BSS_Backend_Opgave.Tests.UnitTests;

public class UserRepositoryTests : IClassFixture<TestFixture>
{
    private readonly TestFixture _fixture;
    private readonly UserRepository _userRepository;

    public UserRepositoryTests(TestFixture fixture)
    {
        _fixture = fixture;
        _userRepository = new UserRepository(_fixture.Context, _fixture.Mapper);
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

        var user = _fixture.Mapper.Map<User>(dto);
        _fixture.Context.User.Add(user);
        await _fixture.Context.SaveChangesAsync(cancellationToken);

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

        var users = _fixture.Mapper.Map<IEnumerable<User>>(dtos);

        _fixture.Context.User.AddRange(users!);
        await _fixture.Context.SaveChangesAsync(cancellationToken);

        var result = await _userRepository.GetUsers(cancellationToken);

        Assert.NotNull(result);
        Assert.IsType<List<UserGetDto>>(result);
        result.ToList().ForEach(user => Assert.IsType<UserGetDto>(user));
    }

    public static IEnumerable<object[]> UserDtoData => new List<object[]>
    {
        new object[] { "JohnJohn1", "johndoe123@example.com", "Doe123" },
        new object[]{"JohnJohn2", "johndoe456@example.com", "Doe456"},
        new object[]{"JohnJohn3", "johndoe789@example.com", "Doe789"}
    };

    [Theory]
    [MemberData(nameof(UserDtoData))]
    public async Task CreateUser_ShouldReturnUserGetDto_WhenDtoIsValid(string name, string email, string password)
    {
        var cancellationToken = new CancellationToken();
        var organisation = new Organisation
        {
            Name = "Organisation"
        };

        _fixture.Context.Organisation.Add(organisation);

        await _fixture.Context.SaveChangesAsync(cancellationToken);

        var dto = new UserCreateDTO
        {
            Name = name,
            Email = email,
            Password = password
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

        var existingUser = _fixture.Mapper.Map<User>(existingUserDto);
        _fixture.Context.User.Add(existingUser);
        _fixture.Context.Organisation.Add(organisation);
        await _fixture.Context.SaveChangesAsync(cancellationToken);

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