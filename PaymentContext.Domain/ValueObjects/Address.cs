using PaymentContext.Shared.ValueObjects;
using Flunt.Br.Extensions;
using Flunt.Br;

namespace PaymentContext.Domain.ValueObjects;
public class Address : ValueObject
{
    public Address(string street, string number, string neighborhood, string city, string state, string contry, string zipCode)
    {
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Contry = contry;
        ZipCode = zipCode;

        AddNotifications(
            new Contract()
                .IsCep(ZipCode, "Address.ZipCode", "CEP inválido")
                .IsNotNullOrWhiteSpace(Street, "Address.Street", "Endereço deve ser preenchida")
                .IsLowerOrEqualsThan(Street.Length, 150, "Address.Street", "Máximo de 150 caracteres para endereço")
        );
    }

    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Neighborhood { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Contry { get; private set; }
    public string ZipCode { get; private set; }
}