using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands;

public class CreateBoletoSubscriptionCommand : Notifiable<Notification>, ICommand
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Document { get; set; }
    public EDocumentType DocumentType { get; set; }

    public string Email { get; set; }

    public string BarCode { get; set; }
    public string BoletoNumber { get; set; }

    public string PaymentNumber { get; set; }
    public DateTime PaidDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public decimal Total { get; set; }
    public decimal TotalPaid { get; set; }
    public string Payer { get; set; }
    public string PayerDocument { get; set; }
    public EDocumentType PayerDocumentType { get; set; }
    public string PayerEmail { get; set; }

    public string Street { get; set; }
    public string Number { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Contry { get; set; }
    public string ZipCode { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNotNullOrWhiteSpace(FirstName, "Name.FirstName", "Nome deve ser preenchido")
            .IsLowerOrEqualsThan(FirstName.Length, 100, "Nome.FirstName", "Máximo de 100 caracteres para nome")
            .IsNotNullOrWhiteSpace(LastName, "Name.LastName", "Sobrenome deve ser preenchido")
            .IsLowerOrEqualsThan(LastName.Length, 100, "Nome.LastName", "Máximo de 100 caracteres para sobrenome")
        );
    }
}