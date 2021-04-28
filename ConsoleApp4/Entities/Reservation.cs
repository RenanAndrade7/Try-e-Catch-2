using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp4.Entities.Exceptions;

namespace ConsoleApp4.Entities
{
    class Reservation
    {
        public int RoomNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Reservation()
        {

        }

        public Reservation(int roomNumber, DateTime checkIn, DateTime checkOut)
        {
            if (checkOut <= checkIn)
            {
                throw new DomainException("Erro a data de checkOut deve ser maior que a data de  checkIn!!");
            }

            RoomNumber = roomNumber;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }
        public int Duration()
        {
            TimeSpan duration = CheckOut.Subtract(CheckIn);
            return (int)duration.TotalDays;
        }

        public void UpdateDates(DateTime checkIn, DateTime checkOut)
        {
            DateTime now = DateTime.Now;

            if (checkIn < now || checkOut < now)
            {
                throw new DomainException( "Erro na reserva o checkIn e checkOut para atualização devem ser datas futuras");
            }

            if (checkOut <= checkIn)
            {
                throw new DomainException( "Erro a data de checkOut deve ser maior que a data de  checkIn!!");
            }

            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public override string ToString()
        {
            return "Room"
                +
                RoomNumber
                + ", check-in: "
                + CheckIn.ToString("dd/MM/yyyy")
                + ", check-out: "
                + CheckOut.ToString("dd/MM/yyyy")
                + " , "
                + Duration()
                + " nights";
        }
    }
}
