module WorkflowsTests

open Domain

open Xunit
open FsUnit.Xunit
open PositiveNumber
open Result

[<Fact>]
let ``prepareOutput function works`` () =
    let c = 
    // Idee: create mit der Guid angewendet via Lift in ein Result, alles andere auch liften was kein Result ist,
    // und dann mit apply alles verbinden.
    // Dann kommt am Ende entweder ein Contact raus, oder eine Liste mit Errors, was nicht geklappt hat
        (lift (Contact.create <| System.Guid.Parse("bba52030-19ce-4c02-b1dd-792b0120855b")))
        <*> (NonEmptyString.create "Homer")
        <*> (NonEmptyString.create "Simpson")
        <*> (lift None)
        <*> (lift None)
        <*> (Result.map Email (Result.bind EmailAddress.create (NonEmptyString.create "a@b.c")))
        <*> (PositiveNumber.create 59)

    ()
            
        // FirstName = 
        // LastName = NonEmptyString.create "Simpson"
        // TwitterProfileUrl = Nothing 
        // DateOfBirth =  Nothing
        // PrimaryContactMethod = EmailAddress.create "a@b.c"
        // Iq = PositiveNumber 59
        // }   

(* 
List<Contact2> contacts = new List<Contact2>
            {
                new Contact2 {Name = "Homer", Iq = 50}, 
                new Contact2 {Name = "Lisa", Iq = 120},
                new Contact2 {Name = "Bart", Iq = 90},
            };

            var contactManager = new ContactManager();
            contactManager.Add(contacts);

            var filterStrategy = new FilterStrategy();
            contactManager.Filter(filterStrategy);
            
            var formattedStrings = contactManager.Format(new SimpleFormatStrategy());
            IPrintStrategy printStrategy = new PrintStrategy();
            
            var result = contactManager.Print(formattedStrings, printStrategy);
            
            result.Should().Be("Lisa,Bart");
     *)