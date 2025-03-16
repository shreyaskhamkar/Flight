# Test-Driven Development (TDD) - Ensuring Test Trustworthiness

## 📌 Introduction
This project follows the **Test-Driven Development (TDD)** approach to ensure high-quality and reliable code. It emphasizes **test trustworthiness** and incorporates the **Devil's Advocate** mindset to challenge assumptions and improve test coverage.

## 📖 What is TDD?
Test-Driven Development (TDD) is a software development methodology where tests are written **before** the actual implementation. It follows the **Red-Green-Refactor** cycle:
1. **Red** - Write a failing test (because the functionality does not exist yet).
2. **Green** - Write minimal code to make the test pass.
3. **Refactor** - Improve the code while ensuring tests still pass.

## 📜 Three Rules of TDD
To effectively follow TDD, developers should adhere to these three fundamental rules:
1. **Write only enough of a test to fail.** Do not write more than necessary.
2. **Write only enough production code to make the test pass.** Avoid unnecessary complexity.
3. **Refactor the code while keeping the tests passing.** Optimize the implementation without changing behavior.

## 🎯 Goals of This Project
- Implement core functionalities using **TDD principles**.
- Ensure **trustworthy tests** (No false positives or negatives, repeatable, independent).
- Use a **Devil's Advocate** approach to uncover hidden issues.

## ✅ Trustworthy Tests - Example (C# xUnit)
```csharp
using Xunit;
using System.Collections.Generic;

public class CalculatorTests
{
    [Theory]
    [InlineData(2, 3, 5)]
    [InlineData(-1, -1, -2)]
    [InlineData(0, 5, 5)]
    public void Add_TwoNumbers_ReturnsSum(int a, int b, int expected)
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        int result = calculator.Add(a, b);

        // Assert
        Assert.Equal(expected, result);
    }
}
```
✔ Ensures tests **fail only when code is incorrect** and **pass only when code is correct**.
✔ Uses **Parameterized Tests (Theory & InlineData)** to test multiple cases efficiently.
✔ Follows **Arrange-Act-Assert (AAA) pattern**.

## 🛠 Configuring In-Memory Database (EF Core)
For unit testing database interactions, an **in-memory database** can be used:

```csharp
using Microsoft.EntityFrameworkCore;

public class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
}

public class DbContextTests
{
    private DbContextOptions<TestDbContext> GetInMemoryDbOptions()
    {
        return new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;
    }
}
```
✔ Provides an **isolated, fast, and reliable** testing environment.
✔ Avoids **external database dependencies**.

## 📝 Naming Conventions in Testing
To maintain clarity and consistency, follow these naming conventions:
1. **MethodUnderTest_Condition_ExpectedBehavior**
   - Example: `Login_WithInvalidCredentials_ShouldFail()`
2. **Use PascalCase for Test Methods**
   - Example: `CalculateTotalPrice_WithDiscount_AppliesCorrectly()`
3. **Group Tests in Separate Files Based on Features**
   - Example: `AuthenticationTests.cs`, `CartServiceTests.cs`

## 😈 Devil’s Advocate Tests - Breaking the System
```csharp
[Fact]
public void Login_WithSQLInjection_Attack_ShouldFail()
{
    var authService = new AuthService();

    bool result = authService.Login("' OR '1'='1'; --", "anything");

    Assert.False(result); // Ensures the system is secure against SQL injection
}
```
✔ Challenges the security of the system by simulating **malicious inputs**.
✔ Ensures the authentication logic is **robust and secure**.

## 🚀 Running the Tests
To run the tests, use the following command:
```sh
dotnet test
```
This will execute all unit tests and provide pass/fail results.

## 🔥 Conclusion
By following **TDD**, ensuring **trustworthy tests**, using **parameterized tests**, configuring **in-memory databases**, and thinking like a **Devil’s Advocate**, we create **reliable, secure, and maintainable software**.

Happy Coding! 🚀

