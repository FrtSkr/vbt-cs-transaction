using System.Data.SqlClient;
// Try - Catch --> hata yönetimi için kullanılır. Uygulamada bulunan hatalar direk kullanıcı karşısına çıkmasın diye uygulanır.

//FormatException
//Try-catch içerisinde olmadığı için kullanıcı FormatException çıktısını görecektir.
// var deneme = "test";
// int deneme2 = Convert.ToInt32(deneme);

// try{
//     var deneme = "test";
//     int deneme2 = Convert.ToInt32(deneme);
// }catch(Exception ex){
//     Console.WriteLine("Hata: "+ ex.ToString());
// }

// try{
//     var deneme = "test";
//     int deneme2 = Convert.ToInt32(deneme);
// }
// //Hataya göre özelleştirme gerçekleştirdik. FormaatException yakalanırsa buraya girecektir. 
// catch(FormatException ex){
//      Console.WriteLine("Format Exception: "+ ex.ToString());
// }
// //Diğer tüm hatalar için bu bloğu kullanacak.
// catch(Exception ex){
//     Console.WriteLine("Hata: "+ ex.ToString());
// }

try{
    var deneme = "test";
    int deneme2 = Convert.ToInt32(deneme);
}
//Hata yönetimini farklı bir metod içerisinde gerçekleştirdik. Böylelikle temiz kod anlayışına uyarız.
catch(FormatException ex) when (LogException(ex)){}
catch(Exception ex) when (LogException(ex)){}

//Her ihtimalde bu bloğa girer. Bitiş anında bir işlem yapılmak isteniyorsa burada gerçekleştirilebilir.
finally {
    Console.WriteLine("İşlem Bitti.");
}


static bool LogException(Exception ex){
    return false;
}

//Transaction
//Local DB ye bağlanacak bir connection string oluşturduk.
string connectionString = @"Data Source=.\LAPTOP-PUT1JTGC;Initial Catalog=test;Integrated Security=True";

SqlTransaction transaction = null;

//contex'in yaşam döngüsü using bloğu kadardır --> Scope
//eğer using blouğunu kullanmasaydık contexle işimiz bittiğinde kapatmak için ayrıca bir yönetim uygulayacaktık. 
using(SqlConnection contex = new SqlConnection()){

}


