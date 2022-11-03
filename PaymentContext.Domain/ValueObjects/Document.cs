using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flunt.Notifications;
using Flunt.Validations;
using Flunt.Br.Extensions;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;
using Flunt.Br;

namespace PaymentContext.Domain.ValueObjects;

public class Document : ValueObject
{
    public Document(string number, EDocumentType type)
    {
        Number = number;
        Type = type;

        switch (Type)
        {
            case EDocumentType.CPF:
                AddNotifications(
                    new Contract()
                        .IsCpf(Number, "Document.Number", "CPF inválido")
                );
                break;
            case EDocumentType.CNPJ:
                AddNotifications(
                    new Contract()
                        .IsCnpj(Number, "Document.Number", "CNPJ inválido")
                );
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

    }

    public string Number { get; private set; }
    public EDocumentType Type { get; private set; }
}