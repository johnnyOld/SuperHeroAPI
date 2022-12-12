using System;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Services.SuperHeroSevice
{
    public class SuperHeroService : ISuperHeroService
    {
        public DataContext Context { get; }
        

        public SuperHeroService(DataContext context)
        {
            Context = context;
        }

        public async Task<List<SuperHero>> AddHero(SuperHero hero)
        {
            Context.SuperHeroes.Add(hero);
            await Context.SaveChangesAsync();
            return await Context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>?> DeleteHero(int id, SuperHero request)
        {
            var hero = await Context.SuperHeroes.FindAsync(id);
            if (hero is null)
            {
                return null;
            }
            Context.SuperHeroes.Remove(hero);

            await Context.SaveChangesAsync();
            return await Context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var heroes = await Context.SuperHeroes.ToListAsync();
            return heroes;
        }

        public async Task<SuperHero?> GetSingleHeroes(int id)
        {
            var hero = await Context.SuperHeroes.FindAsync(id);
            if (hero is null)
            {
                return null;
            }
            return hero;
        }

        public async Task<List<SuperHero>?> UpdateHero(int id, SuperHero request)
        {
            var hero = await Context.SuperHeroes.FindAsync(id);
            if (hero is null)
            {
                return null;
            }
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;

            await Context.SaveChangesAsync();
            return await Context.SuperHeroes.ToListAsync();

        }
    }
}

