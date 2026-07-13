using System.Reflection.PortableExecutable;

List<Person> people = new();

while (true)
{
    ShowMenu();

    System.Console.WriteLine("\nPilih Menu : ");
    string? menu = Console.ReadLine();

    switch (menu)
    {
        case "1":
            people.Add(CreatePerson());
            System.Console.WriteLine("\nData berhasil ditambahkan");
            break;

        case "2":
            PrintPeople(people);
            break;

        case "0":
            Console.WriteLine("Terima Kasih");
            return;

    }
    Console.WriteLine();

}

static void ShowMenu()
{
    System.Console.WriteLine("""
    ============================
    PEOPLE MANAGEMENT
    ============================
    
    1. Tambah Orang
    2. Lihat Semua Orang
    0. Keluar
    """);
}


static Person CreatePerson()
{
    Console.Write("Nama : ");
    string? name = Console.ReadLine();

    Console.Write("Umur : ");

    int age;

    while (!int.TryParse(Console.ReadLine(), out age))
    {
        Console.Write("Umur harus angka. Masukkan lagi : ");
    }

    Console.Write("Tinggi Badan : ");

    double height;

    while (!double.TryParse(Console.ReadLine(), out height))
    {
        Console.Write("Tinggi harus angka. Masukkan lagi : ");
    }

    return new Person
    {
        Name = name ?? "",
        Age = age,
        Height = height
    };
}
static void PrintPerson(Person person)
{
    System.Console.WriteLine($"""
======Biodata======
Nama            :{person.Name}
Umur            : {person.Age}
Tinggi badan    : {person.Height}
===================
""");
}


static void PrintPeople(List<Person> people)
{
    // foreach (Person person in people)
    // {
    //     System.Console.WriteLine($"""
    //         ======Biodata======
    //         Nama            :{person.Name}
    //         Umur            : {person.Age}
    //         Tinggi badan    : {person.Height}
    //         ===================
    //         """);
    // }

    // **Reuse method yang sudah ada** 
    int nomor = 1;
    foreach (Person person in people)
    {
        System.Console.WriteLine($"Orang ke {nomor}");
        PrintPerson(person);
        nomor++;
    }
}

