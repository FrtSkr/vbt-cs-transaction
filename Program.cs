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

// try{
//     var deneme = "test";
//     int deneme2 = Convert.ToInt32(deneme);
// }
// //Hata yönetimini farklı bir metod içerisinde gerçekleştirdik. Böylelikle temiz kod anlayışına uyarız.
// catch(FormatException ex) when (LogException(ex)){}
// catch(Exception ex) when (LogException(ex)){}

// //Her ihtimalde bu bloğa girer. Bitiş anında bir işlem yapılmak isteniyorsa burada gerçekleştirilebilir.
// finally {
//     Console.WriteLine("İşlem Bitti.");
// }


// static bool LogException(Exception ex){
//     return false;
// }

//Transaction

//Local DB ye bağlanacak bir connection string oluşturduk.
string connectionString = @"";
SqlTransaction transaction = null;

//contex'in yaşam döngüsü using bloğu kadardır
//eğer using blouğunu kullanmasaydık contexle işimiz bittiğinde kapatmak için ayrıca bir yönetim uygulayacaktık. 
// using(SqlConnection contex = new SqlConnection(connectionString)){
//     try{

//         //Veritabanı erişimini açtık
//         contex.Open();
//         //Oluşturduğumuz transaction'ı contex'e bağladık
//         transaction = contex.BeginTransaction();

//         SqlCommand com = new SqlCommand("insert into Personel (IdPersonel, PersonelName, PersonelSurname) values (1, 'test1', 'test2')", contex, transaction);
//         SqlCommand com2 = new SqlCommand("insert into Personel (IdPersonel, PersonelName, PersonelSurname) values (2, 'test1', 'test2')", contex, transaction);

//         com.ExecuteNonQuery();
//         com2.ExecuteNonQuery();
//         transaction.Commit();

//     }catch(Exception e){
//         //Hata alırsak tüm transaction işlemlerini geçersiz kıl.
//         transaction.Rollback();
//     }
//     finally{
//         contex.Close();
//     }

using(SqlConnection contex = new SqlConnection(connectionString)){
    try{
        contex.Open();
        transaction = contex.BeginTransaction();
        int deneme= 1;
        SqlCommand com = new SqlCommand("insert into Personel (IdPersonel, PersonelName, PersonelSurname) values (1, 'test1', 'test2')", contex, transaction);
        SqlCommand com2 = new SqlCommand("insert into Personel (IdPersonel, PersonelName, PersonelSurname) values (2, 'test1', 'test2')", contex, transaction);
        SqlCommand com3 = new SqlCommand("insert into Personel (IdPersonel, PersonelName, PersonelSurname) values (3, ${deneme}, 'test2')", contex, transaction);

        //com nesne sorgusunu çalıştır.
        com.ExecuteNonQuery();
        //transaction'ı kayıt et.
        transaction.Save("burayaKadarRollback");
        com2.ExecuteNonQuery();
        com3.ExecuteNonQuery();
        //İşlem kaydı
        transaction.Commit();
        Console.WriteLine("SQL Tamam");

    }catch(Exception e){
        //Eğer SQL bağlantısında bir sorun olursa Open metodu çalışmaz hataya düşecektir. Bu yüzden de transaction null olabilir.
        if(transaction != null){
            //Eğer bir hata durumu olursa transaction'ı "burayaKadarRollback" adımına kadar geri al.
            transaction.Rollback("burayaKadarRollback");
            transaction.Commit();
            Console.WriteLine("SQL HATA");
        }else{
            Console.WriteLine("Transaction NULL");
        }
    }
    finally{
        contex.Dispose();
    }
}


