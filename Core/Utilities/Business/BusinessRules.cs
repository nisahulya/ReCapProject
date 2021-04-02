using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        //Buradaki iş motorunu List olarakda döndürebiliriz. Yoğurt yiyiş
        public static IResult Run(params IResult[] logics) //logics iş kuralları demektir.
        {
            foreach (var logic in logics) // her bir iş kuralını gez
            {
                if (!logic.Success) //iş kuralı başarısız ise
                {
                    return logic; // iş kuralında hata döndür.
                }
            }
            return null; // Hatalı değilse bir şey döndürme boş kalsın
        }
    }
}
