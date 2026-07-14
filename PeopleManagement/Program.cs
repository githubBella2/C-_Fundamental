using System.Net;
using System.Reflection.PortableExecutable;

PersonService service = new PersonService();
while (true)
{
    ShowMenu();

    System.Console.WriteLine("\nPilih Menu : ");
    string? menu = Console.ReadLine();

    switch (menu)
    {
        case "1":
        service.AddPerson();
            System.Console.WriteLine("\nData berhasil ditambahkan");
            break;

        // case "2":
        //     PrintPeople(people);
        //     break;

        // case "3":
        //     SearchPerson(people);
        //     break;

        // case "4":
        //     FindAdult(people);
        //     break;

        // case "5":
        //     DeletePerson(people);
        //     break;

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
    3. Cari Orang
    4. Cari Orang yang umurnya lebih dari 20 tahun
    5. Hapus Orang
    0. Keluar
    """);
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

static void SearchPerson(List<Person> people)
{
    System.Console.Write("Masukkan Nama : ");
    string? keyword = Console.ReadLine();

    bool ditemukan = false;

    foreach (Person person in people)
    {
        if (person.Name.Equals(keyword, StringComparison.OrdinalIgnoreCase))
        {
            PrintPerson(person);
            ditemukan = true;
        }
    }

    if (!ditemukan)
    {
        System.Console.WriteLine("Data tidak ditemukan");
    }
}

static void FindAdult(List<Person> people)
{
    Person? person = people.FirstOrDefault(p => p.Age > 20);

    if (person == null)
    {
        System.Console.WriteLine("Tidak ada");
        return;
    }
    PrintPerson(person);
}

static void DeletePerson(List<Person> people)
{
    System.Console.WriteLine("Masukkan Nama: ");
    string? keyword = Console.ReadLine();

    Person? person = people.FirstOrDefault(p => p.Name.Equals(keyword, StringComparison.OrdinalIgnoreCase));
    if (person == null)
    {
        System.Console.WriteLine("Data tidak ditemukan.");
    }
    people.Remove(person);
    System.Console.WriteLine("Data berhasil dihapus");

}