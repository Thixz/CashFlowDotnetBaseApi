using Bogus;
using CashFlow.Communication.Requests;

namespace CommonTestUtilities.Requests;
public class RequestRegisterUserJsonBuilder
{
    public static RequestRegisterUserJson Build()
    {
        return new Faker<RequestRegisterUserJson>()
           .RuleFor(r => r.Name, faker => faker.Person.FirstName)
           .RuleFor(user => user.Email, (faker, user) => faker.Internet.Email(user.Name))
           .RuleFor(r => r.Password, faker => faker.Internet.Password(prefix:"!Aa1"));
    }
}
