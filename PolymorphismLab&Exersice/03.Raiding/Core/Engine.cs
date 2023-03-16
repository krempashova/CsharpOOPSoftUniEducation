namespace Raiding.Core
{
    using IO.Interfaces;
    using Raiding.Core.Interfaces;
    using Raiding.Factoris.Interfaces;
    using Raiding.Models;
    using Raiding.Models.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IHeroFactory heroFactory;

        private readonly ICollection<IBaseHero> heroes;
        public Engine(IReader reader,IWriter writer,IHeroFactory heroFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.heroFactory = heroFactory;
            heroes = new List<IBaseHero>();
        }
        public void Run()
        {
            int n = int.Parse(reader.ReadLine());
            for (int i = 0; i < n; i++)
            {

                string name = reader.ReadLine();
                string type = reader.ReadLine();
                try
                {
                    heroes.Add(heroFactory.CreatedHeros(name, type));
                }
                catch (ArgumentException EX)
                {

                    writer.WriteLine(EX.Message);
                    i--;
                }
                catch (Exception ex)
                {
                    throw;
                }


            }
            foreach (var hero in heroes)
            {
                writer.WriteLine(hero.CastAbility());
            }
            int bossPower = int.Parse(reader.ReadLine());
             if(heroes.Sum(c=>c.Power)>=bossPower)
            {
               writer.WriteLine("Victory!");
            }
             else
            {
                writer.WriteLine("Defeat...");
            }

        }
    }
}
