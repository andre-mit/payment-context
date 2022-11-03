using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

        AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotNullOrWhiteSpace(FirstName, "Name.FirstName", "Nome deve ser preenchido")
                .IsLowerOrEqualsThan(FirstName.Length, 100, "Nome.FirstName", "Máximo de 100 caracteres para nome")
                .IsNotNullOrWhiteSpace(LastName, "Name.LastName", "Sobrenome deve ser preenchido")
                .IsLowerOrEqualsThan(LastName.Length, 100, "Nome.LastName", "Máximo de 100 caracteres para sobrenome")
        );
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
}