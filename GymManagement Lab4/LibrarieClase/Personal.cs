using System;

namespace LibrarieClase
{
    public class Personal
    {
        private char SEPARATOR_PRINCIPAL_FISIER = ';';

        public int idPersonal;
        public string nume;
        public string prenume;
        public int varsta;
        public string nr_telefon;
        public string data_angajarii;
        public string functie;

        public Personal()
        {
            nume = prenume = nr_telefon = data_angajarii = functie = string.Empty;
            varsta = 0;
        }

        public Personal(int idPersonal,string nume,string prenume,int varsta,string nr_telefon,string data_angajarii,string functie)
        {
            this.idPersonal = idPersonal;
            this.nume = nume;
            this.prenume = prenume;
            this.varsta = varsta;
            this.nr_telefon = nr_telefon;
            this.data_angajarii = data_angajarii;
            this.functie = functie;
        }

        public Personal(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            this.idPersonal = Convert.ToInt32(dateFisier[0]);
            this.nume = dateFisier[1];
            this.prenume = dateFisier[2];
            this.varsta = Convert.ToInt32(dateFisier[3]);
            this.nr_telefon = dateFisier[4];
            this.data_angajarii = dateFisier[5];
            this.functie = dateFisier[6];
        }

        public string ConversieLaSir_PentruFisier()
        {
            string obiectMembruPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}",
                SEPARATOR_PRINCIPAL_FISIER, idPersonal, nume, prenume, varsta, nr_telefon, data_angajarii, functie);

            return obiectMembruPentruFisier;
        }

        public string GetInfoCompletPersonal()
        {
            string infoPersonal = string.Format("Id Personal: {0}\nNume Prenume: {1} {2}\nVarsta: {3}\nNumar telefon: {4}\n" +
                "Data angajarii: {5}\nFucntie: {6}\n", idPersonal, nume, prenume, varsta, nr_telefon, data_angajarii, functie);

            return infoPersonal;
        }

        public void SetIdPersonal(int idPersonal)
        {
            this.idPersonal= idPersonal;
        }

        public int GetIdPersonal()
        {
            return idPersonal;
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
