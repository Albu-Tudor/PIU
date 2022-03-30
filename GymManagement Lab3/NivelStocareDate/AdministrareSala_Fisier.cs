using System;
using System.IO;
using LibrarieClase;

namespace NivelStocareDate
{
    public class AdministrareSala_Fisier
    {
        private const int NR_MAX_MEMBRI = 50;
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
    }
}
