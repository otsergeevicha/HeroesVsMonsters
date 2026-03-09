using System.Collections.Generic;
using Source.Scripts.HeroBase;
using Source.Scripts.Infrastructure.Interfaces;
using Source.Scripts.Infrastructure.SO;
using UnityEngine;

namespace Source.Scripts.Infrastructure.Pools
{
    public class PoolHeroes
    {
        private readonly List<Hero> _heroes = new ();

        public PoolHeroes(GameConfig config, IGameFactory gameFactory)
        {
            if (config.Heroes.Entities == null || config.Heroes.Entities.Count == 0)
            {
                Debug.Log("No heroes to spawn");
                return;
            }
            
            foreach (GameConfig.SettingHeroes.SettingHeroEntity settingHeroEntity in config.Heroes.Entities)
            {
                Hero hero = gameFactory.CreateHero(settingHeroEntity.LinkPrefab);
                hero.Construct();
                hero.InActive();
                _heroes.Add(hero);
            }
        }
    }
}