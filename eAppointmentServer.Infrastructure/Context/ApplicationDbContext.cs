using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAppointmentServer.Infrastructure.Context
{
    //Bu class ı diğer katmanlar direkt kullanamasın diye internal.
    //Repository kullanıldığı için ya onun üzerinden yada Identity kütüphanesi için kullanılan user managerlar yada diğer managerlar üzerinden işlem yapabilmesi lazım.
    internal sealed class ApplicationDbContext
    {
    }
}
