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
            break;

        case "2":
            service.PrintPeople();
            break;

        case "3":
            service.SearchPerson();
            break;

        case "4":
            service.FindAdult();
            break;

        case "5":
            service.DeletePerson();
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
    3. Cari Orang
    4. Cari Orang yang umurnya lebih dari 20 tahun
    5. Hapus Orang
    0. Keluar
    """);
}


