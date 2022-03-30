using System;


namespace LibrarieClase
{
    public class Membru
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const int PRET_ABONAMENT_STUDENT = 90;
        private const int PRET_ABONAMENT_NORMAL = 130;

        private int idMembru;
        private string nume;
        private string prenume;
        private char sex;
        private string data_creare;
        private string tip_abonament;
        private int pret;
        private int perioada;

        public Membru()
        {
            idMembru = 0;
            nume = prenume = data_creare = tip_abonament = string.Empty;
            sex = '\0';
            perioada = 0;
        }

        public Membru(int idMembru, string nume, string prenume, char sex, string data_creare, string tip_abonament, int perioada)
        {
            this.idMembru = idMembru;
            this.nume = nume;
            this.prenume = prenume;
            this.sex = sex;
            this.data_creare = data_creare;
            this.tip_abonament = tip_abonament;
            this.perioada = perioada;
            if (tip_abonament == "Student")
                this.pret = PRET_ABONAMENT_STUDENT * this.perioada;
            else
                this.pret = PRET_ABONAMENT_NORMAL * this.perioada;
        }

        public Membru(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            this.idMembru = Convert.ToInt32(dateFisier[0]);
            this.nume = dateFisier[1];
            this.prenume = dateFisier[2];
            this.sex = Convert.ToChar(dateFisier[3]);
            this.data_creare = dateFisier[4];
            this.tip_abonament = dateFisier[5];
            this.pret = Convert.ToInt32(dateFisier[6]);
            this.perioada = Convert.ToInt32(dateFisier[7]);
        }

        public string ConversieLaSir_PentruFisier()
        {
            string obiectMembruPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}",
                SEPARATOR_PRINCIPAL_FISIER, idMembru, nume, prenume, sex, data_creare, tip_abonament, pret, perioada);

            return obiectMembruPentruFisier;
        }

        public string GetInfoCompletMembru()
        {
            string infoMembru = string.Format("Id Membru: {0}\nNume Prenume: {1} {2}\nSex: {3}\nData creare abonament: {4}\n" +
                    "Tip abonament:{5}\nPret:{6}\nDurata abonament: {7}\n", idMembru, nume, prenume, sex, data_creare, tip_abonament,
                    pret, perioada);


            return infoMembru;
        }

        public void SetIdMembru(int idMembru)
        {
            this.idMembru = idMembru;
        }

        public int GetIdMembru()
        {
            return idMembru;
        }

        public string GetNume()
        {
            return nume;
        }

        public string GetPrenume()
        {
            return prenume;
        }
    }
}
