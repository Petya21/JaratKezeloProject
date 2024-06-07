using System;
using System.Collections.Generic;

namespace JaratKezeloProject
{
    public class NegativKesesException : Exception
    {
        public NegativKesesException(string message) : base(message)
        {
        }
    }
    public class Jarat
    {
        public string JaratSzam { get; set; }
        public string RepterHonnan { get; set; }
        public string RepterHova { get; set; }
        public DateTime Indulas { get; set; }
        public TimeSpan Kesleltetes { get; set; }

        public Jarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas)
        {
            JaratSzam = jaratSzam;
            RepterHonnan = repterHonnan;
            RepterHova = repterHova;
            Indulas = indulas;
            Kesleltetes = TimeSpan.Zero;
        }
    }

    public class JaratKezelo
    {
        private Dictionary<string, Jarat> jaratok;

        public JaratKezelo()
        {
            jaratok = new Dictionary<string, Jarat>();
        }

        public void UjJarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas)
        {
            if (string.IsNullOrWhiteSpace(jaratSzam))
            {
                throw new ArgumentException("A járatszám nem lehet üres.");
            }

            if (string.IsNullOrWhiteSpace(repterHonnan))
            {
                throw new ArgumentException("A kezdeti repülőtér nem lehet üres.");
            }

            if (string.IsNullOrWhiteSpace(repterHova))
            {
                throw new ArgumentException("A cél repülőtér nem lehet üres.");
            }

            if (jaratok.ContainsKey(jaratSzam))
            {
                throw new ArgumentException("A járatszám már létezik.");
            }

            Jarat ujJarat = new Jarat(jaratSzam, repterHonnan, repterHova, indulas);
            jaratok.Add(jaratSzam, ujJarat);
        }

        public void Keses(string jaratSzam, TimeSpan keses)
        {
            if (!jaratok.ContainsKey(jaratSzam))
            {
                throw new ArgumentException("Nem létező járatszám.");
            }

            var jarat = jaratok[jaratSzam];
            var ujKeses = jarat.Kesleltetes + keses;

            if (ujKeses < TimeSpan.Zero)
            {
                throw new NegativKesesException("A késés nem lehet negatív.");
            }

            jarat.Kesleltetes = ujKeses;
        }

        public DateTime MikorIndul(string jaratSzam)
        {
            if (!jaratok.ContainsKey(jaratSzam))
            {
                throw new ArgumentException("Nem létező járatszám.");
            }

            var jarat = jaratok[jaratSzam];
            return jarat.Indulas + jarat.Kesleltetes;
        }

        public List<string> JaratokRepuloterrol(string repter)
        {
            var jaratokRepuloterrol = jaratok.Values
                .Where(j => j.RepterHonnan.Equals(repter, StringComparison.OrdinalIgnoreCase))
                .Select(j => j.JaratSzam)
                .ToList();

            return jaratokRepuloterrol;
        }
    }
}
