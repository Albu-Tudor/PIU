using System;
using System.IO;
using LibrarieClase;

namespace NivelStocareDate
{
    public class AdministrareSala_Fisier
    {
        private const int NR_MAX_MEMBRI = 50;
        private const int NR_MAX_PERSONAL = 50;
        private string numeFisier;

        public AdministrareSala_Fisier(string numeFisier)
        {
            this.numeFisier = numeFisier;

            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void addMembru(Membru membru)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(membru.ConversieLaSir_PentruFisier());
            }
        }

        public void addPersonal(Personal personal)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(personal.ConversieLaSir_PentruFisier());
            }
        }

        public Membru[] GetMembri(out int nrMembri)
        {
            Membru[] membri = new Membru[NR_MAX_MEMBRI];

            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrMembri = 0;

                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    membri[nrMembri++] = new Membru(linieFisier);
                }
            }

            return membri;
        }

        public Personal[] GetPersonal(out int nrPersonal)
        {
            Personal[] lista_personal = new Personal[NR_MAX_PERSONAL];

            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrPersonal = 0;

                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    lista_personal[nrPersonal++] = new Personal(linieFisier);
                }
            }

            return lista_personal;
        }
    }
}
