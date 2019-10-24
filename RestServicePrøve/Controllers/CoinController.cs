using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ModelLibrary;

namespace RestServicePrøve.Controllers
{
    [Route("api/Coins")]
    [ApiController]
    public class CoinController : ControllerBase
    {

        public static List<Coins> data = new List<Coins>
        {
            new Coins(1, "Gold DK 1640", 2500, "Mike"),
            new Coins(2, "Gold NL 1764", 5000, "Anbo"),
            new Coins(3, "Gold FR1644", 35000, "Hammer"),
            new Coins(4, "Gold FR 1644", 0, "Auction"),
            new Coins(5, "Silver GR 333", 2500, "Mike")




        };
        // GET: api/Coin
        [HttpGet]
        public IEnumerable<Coins> Get()
        {
            return data;
        }

        // GET: api/Coin/5
        [HttpGet("{id}", Name = "Get")]
        public Coins Get(int id)
        {
            return data.Find(i => i.Id == id);
        }

        // POST: api/Coin
        [HttpPost]
        public void Post([FromBody] Coins value)
        {
            data.Add(value);
        }

        // PUT: api/Coin/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Coins value)
        {
            Coins coin = Get(id);
            if (coin != null)
            {
                coin.Bud = value.Bud;
                coin.Navn = value.Navn;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Coins coin = Get(id);
            if (coin != null)
            {
                data.Remove(coin);
            }
            
        }

        // /api/Coins/Name/"substring"
        [HttpGet]
        [Route("Name/{substring}")]
        public List<Coins> GetFromSubString(string substring)
        {
            return data.FindAll(i => i.Navn.Contains(substring));
        }

        //Søg bud range
        [HttpGet]
        [Route("search")]
        public List<Coins> filterCoins([FromQuery] CoinsQuery qcoins)
        {
            List<Coins> coins = new List<Coins>();

            if (qcoins.MaxBud == 0)
            {
                qcoins.MaxBud = int.MaxValue;
            }


            foreach (Coins coin in data)
            {
                if (qcoins.MinBud <= coin.Bud && coin.Bud <= qcoins.MaxBud)
                {
                    coins.Add(coin);
                }
            }

            return coins;
        }
    }
}
