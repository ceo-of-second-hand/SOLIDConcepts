/*
   були порушені принципи єдиної відповідальності і інверсії залежностей
*/
using System;

class Email
{
    public string Theme { get; set; }
    public string From { get; set; }
    public string To { get; set; }
}

interface ILogger
{
    void Log(string message);
}

class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

class EmailSender
{
    private readonly ILogger logger;

    public EmailSender(ILogger logger)
    {
        this.logger = logger;
    }

    public void Send(Email email)
    {
        logger.Log($"Email from '{email.From}' to '{email.To}' was sent");
    }
}

class Program
{
    static void Main(string[] args)
    {
        ILogger logger = new ConsoleLogger();
        EmailSender emailSender = new EmailSender(logger);

        Email e1 = new Email { From = "Me", To = "Vasya", Theme = "Who are you?" };
        Email e2 = new Email { From = "Vasya", To = "Me", Theme = "vacuum cleaners!" };
        Email e3 = new Email { From = "Kolya", To = "Vasya", Theme = "No! Thanks!" };
        Email e4 = new Email { From = "Vasya", To = "Me", Theme = "washing machines!" };
        Email e5 = new Email { From = "Me", To = "Vasya", Theme = "Yes" };
        Email e6 = new Email { From = "Vasya", To = "Petya", Theme = "+2" };

        emailSender.Send(e1);
        emailSender.Send(e2);
        emailSender.Send(e3);
        emailSender.Send(e4);
        emailSender.Send(e5);
        emailSender.Send(e6);

        Console.ReadKey();
    }
}
