using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Email : ValueObject
{
    public string Address { get; private set; }

    public Email(string address)
    {
        Address = address;

        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsEmail(Address, "Email.Address", "E-mail inválido")
        );
    }
}