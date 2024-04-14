using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPWA.Models;

namespace TPWA.Interfaces
{
    public interface IBallRepository
    {
        List<Ball> GetAllBalls();
        void AddBall(Ball ball);
        void RemoveBall(Ball ball);
    }
}
