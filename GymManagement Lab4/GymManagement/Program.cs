using System;
using System.Configuration;
using NivelStocareDate;
using LibrarieClase;

namespace GymManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            string fisierMembri = ConfigurationManager.AppSettings.Get("membri");
            string fisierPersonal = ConfigurationManager.AppSettings.Get("personal");

            AdministrareSala_Fisier adminMembri = new AdministrareSala_Fisier(fisierMembri);
            AdministrareSala_Fisier adminPersonal = new AdministrareSala_Fisier(fisierPersonal);
            Membru membruNou = new Membru();
            Personal personalNou = new Personal();

            int nrMembri = 0, nrPersonal = 0;
            adminMembri.GetMembri(out nrMembri);
            adminPersonal.GetPersonal(out nrPersonal);

            string optiune;
            do
            {
                Console.WriteLine("C. Citire informatii membru de la tastatura");
                Console.WriteLine("R. Citire informatii despre personal de la tastatura");
                Console.WriteLine("A. Afiseaza toate datele despre un membru dat");
                Console.WriteLine("P. Afiseaza toate datele despre un personal dat");
                Console.WriteLine("F. Afisare membri din fisier");
                Console.WriteLine("D. Afisare personal din fisier");
                Console.WriteLine("S. Salvare membru in fisier");
                Console.WriteLine("L. Salveaza personal in fisier");
                Console.WriteLine("X. Inchidere program");
                Console.Write("Alegeti o optiune: ");
                optiune = Console.ReadLine();

                switch (optiune.ToUpper())
                {
                    case "C":
                        membruNou = CitireMembruTastatura();
                        Console.WriteLine();

                        break;
                    case "R":
                        personalNou = CitirePersonalTastatura();
                        Console.WriteLine();

                        break;
                    case "A":
                        Membru[] lista_membri = adminMembri.GetMembri(out nrMembri);
                        cautareMembru(lista_membri, nrMembri);

                        break;
                    case "P":
                        Personal[] lista_personal = adminPersonal.GetPersonal(out nrPersonal);
                        cautarePersonal(lista_personal, nrMembri);

                        break;
                    case "F":
                        Membru[] membri = adminMembri.GetMembri(out nrMembri);
                        AfisareMembri(membri, nrMembri);
                        Console.WriteLine();

                        break;
                    case "D":
                        Personal[] lista_pers = adminPersonal.GetPersonal(out nrPersonal);
                        AfisarePersonal(lista_pers, nrPersonal);
                        Console.WriteLine();

                        break;
                    case "S":
                        int idMembru = nrMembri + 1;
                        membruNou.SetIdMembru(idMembru);
                        adminMembri.addMembru(membruNou);

                        nrMembri = nrMembri + 1;
                        Console.WriteLine("Membrul a fost salvat cu succes\n");

                        break;
                    case "L":
                        int idPersonal = nrPersonal + 1;
                        personalNou.SetIdPersonal(idPersonal);
                        adminPersonal.addPersonal(personalNou);

                        nrPersonal = nrPersonal + 1;
                        Console.WriteLine("Personalul a fost salvat cu succes\n");

                        break;
                    case "X":
                        return;
                    default:
                        Console.WriteLine("Nu exista optiunea selectata\n");
                        break;
                }
            }
            while (optiune.ToUpper() != "X");

            Console.ReadLine();
        }

        public static void cautareMembru(Membru[] membri, int nrMembri)
        {
            Console.Write("Introduceti numele persoanei cautate: ");
            string nume = Console.ReadLine();

            Console.Write("Introduceti prenumele persoanei cautate: ");
            string prenume = Console.ReadLine();

            string info = string.Empty;
            for (int contor = 0; contor < nrMembri; contor++)
            {
                if (membri[contor].GetNume() == nume && membri[contor].GetPrenume() == prenume)
                {
                    info = membri[contor].GetInfoCompletMembru();
                    Console.WriteLine(info);
                }
            }
            if (info == string.Empty)
                Console.WriteLine("Nu exista nicun membru cu numele respectiv\n");
        }

        public static void cautarePersonal(Personal[] lista_personal, int nrPersonal)
        {
            Console.Write("Introduceti numele personalului cautate: ");
            string nume = Console.ReadLine();

            Console.Write("Introduceti prenumele personalului cautate: ");
            string prenume = Console.ReadLine();

            string info = string.Empty;
            for (int contor = 0; contor < nrPersonal; contor++)
            {
                if (lista_personal[contor].GetNume() == nume && lista_personal[contor].GetPrenume() == prenume)
                {
                    info = lista_personal[contor].GetInfoCompletPersonal();
                    Console.WriteLine(info);
                }
            }
            if (info == string.Empty)
                Console.WriteLine("Nu exista nicun membru cu numele respectiv\n");
        }

        public static void AfisareMembru(Membru membru)
        {
            string infoMembru = string.Format("Membrul cu id-ul #{0} are numele: {1} {2}",
                membru.GetIdMembru(),
                membru.GetNume() ?? "NECUNOSCUT",
                membru.GetPrenume() ?? "NECUNOSCUT");

            Console.WriteLine(infoMembru);
        }

        public static void AfisarePersonal(Personal personal)
        {
            string infoPersonal = string.Format("Personalul cu id-ul #{0} are numele: {1} {2}",
                personal.GetIdPersonal(),
                personal.GetNume() ?? "NECUNOSCUT",
                personal.GetPrenume() ?? "NECUNOSCUT");

            Console.WriteLine(infoPersonal);
        }

        public static void AfisareMembri(Membru[] membri, int nrMembri)
        {
            Console.Write("Membri sunt:\n");
            for (int contor = 0; contor < nrMembri; contor++)
            {
                AfisareMembru(membri[contor]);
            }
        }

        public static void AfisarePersonal(Personal[] lista_personal, int nrPersonal)
        {
            Console.Write("Personalul este:\n");
            for (int contor = 0; contor < nrPersonal; contor++)
            {
                AfisarePersonal(lista_personal[contor]);
            }
        }

        public static Membru CitireMembruTastatura()
        {
            Console.Write("Introduceti numele membrului: ");
            string nume = Console.ReadLine();

            Console.Write("Introduceti prenumele membrului: ");
            string prenume = Console.ReadLine();

            Console.Write("Introduceti sexul(M/F): ");
            char sex = Convert.ToChar(Console.ReadLine());

            Console.Write("Introduceti data creari abonamentului (dd/mm/yyyy): ");
            string data_creare = Console.ReadLine();

            Console.Write("Introduceti tipul abonamentului (Student/Normal): ");
            string tip_abonament = Console.ReadLine();

            Console.Write("Introduceti durata abonamentului (1/2/3/6/12 luni): ");
            int perioada = Convert.ToInt32(Console.ReadLine());

            Membru membru = new Membru(0, nume, prenume, sex, data_creare, tip_abonament, perioada);

            return membru;
        }

        public static Personal CitirePersonalTastatura()
        {
            Console.Write("Introduceti numele noului membru din personal: ");
            string nume = Console.ReadLine();

            Console.Write("Introduceti prenumele noului membru din personal: ");
            string prenume = Console.ReadLine();

            Console.Write("Introduceti varsta: ");
            int varsta = Convert.ToInt32(Console.ReadLine());

            Console.Write("Introduceti numarul de telefon: ");
            string nr_telefon = Console.ReadLine();

            Console.Write("Introduceti data angajarii: ");
            string data_angajarii = Console.ReadLine();

            Console.Write("Introduceti functia(Receptioner / Antrenor / Mecanic / Om de serviciu)");
            string functie = Console.ReadLine();

            Personal personal = new Personal(0, nume, prenume, varsta, nr_telefon, data_angajarii, functie);

            return personal;
        }
    }
}
