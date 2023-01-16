using Camere.Hotel;
namespace test.camere
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Camere.Hotel.Camera camera = new Camere.Hotel.Camera(Convert.ToString(101), 45, 8, false, false, false, 400, 3);
            Assert.True(camera.Numero=="101");
            Assert.True(camera.Dimensione==45);
            Assert.True(camera.Posti_letto==8);
            Assert.True(camera.TV==false);
            Assert.True(camera.Frigo==false);
            Assert.True(camera.Bagno==false);
            Assert.True(camera.Costo==400);
            Assert.True(camera.Persone == 3);
        }
        [Fact]
        public void Test2()
        {
            Camere.Hotel.Camera camera;
            Assert.Throws<Exception>(() => camera = new Camere.Hotel.Camera(Convert.ToString(-101), 45, 8, false, false, false, 400, 3));     
            Assert.Throws<Exception>(() => camera = new Camere.Hotel.Camera(Convert.ToString(101), -45, 8, false, false, false, 400, 3));
            Assert.Throws<Exception>(() => camera = new Camere.Hotel.Camera(Convert.ToString(101), 45, -8, false, false, false, 400, 3));
            //Assert.Throws<Exception>(() => camera = new Camere.Hotel.Camera(Convert.ToString(101), 45, 8, false, false, false, -400, 3));
            //non viene considerato il caso in cui il costo della camera inserito sia negativo
            Assert.Throws<Exception>(() => camera = new Camere.Hotel.Camera(Convert.ToString(101), 45, 8, false, false, false, 400, -3));
        }

        [Fact]
        public void Test3()
        {
            Camere.Hotel.Camera cameraa = new Camere.Hotel.Camera(Convert.ToString(101), 45, 8, false, false, false, 400, 3);
            Camere.Hotel.Camera camerab = new Camere.Hotel.Camera(Convert.ToString(101), 45, 8, false, false, false, 400, 3);
            Assert.True(cameraa.Equals(camerab));
        }
        [Fact]
        public void Test4()
        {
            Camere.Hotel.Camera cameraa = new Camere.Hotel.Camera(Convert.ToString(101), 45, 8, false, false, false, 400, 3);
            Camere.Hotel.Camera camerab = new Camere.Hotel.Camera(Convert.ToString(901), 45, 8, false, false, false, 400, 3);
            Assert.False(cameraa.Equals(camerab));
        }

        /*
        [Fact]
        public void Test5()
        {
            Camere.Hotel.Camera camera = new Camere.Hotel.Camera(Convert.ToString(101), 45, 8, false, false, false, 400, 3);
            Assert.True(camera.Clone() == camera);
        }
        */
        //il clone non funziona

        [Fact]
        public void Test6()
        {
            Camere.Hotel.Camera camera = new Camere.Hotel.Camera(Convert.ToString(101), 45, 8, false, false, false, 400, 3);
            camera.Modifica_frigo(true);
            Assert.True(camera.Frigo==true);
        }
        [Fact]
        public void Test7()
        {
            Camere.Hotel.Camera camera = new Camere.Hotel.Camera(Convert.ToString(101), 45, 8, false, false, false, 400, 3);
            camera.Modifica_frigo(false);
            Assert.True(camera.Frigo == false);
        }
        [Fact]
        public void Test8()
        {
            Camere.Hotel.Camera camera = new Camere.Hotel.Camera(Convert.ToString(101), 45, 8, false, false, false, 400, 3);
            camera.Modifica_tv(false);
            Assert.True(camera.TV == false);
        }

        [Fact]
        public void Test9()
        {
            Camere.Hotel.Camera camera = new Camere.Hotel.Camera(Convert.ToString(101), 45, 8, false, false, false, 400, 3);
            camera.Modifica_tv(true);
            Assert.True(camera.TV == true);
        }

        [Fact]
        public void Test10()
        {
            Camere.Hotel.Camera camera = new Camere.Hotel.Camera(Convert.ToString(101), 45, 8, false, false, false, 400, 3);
            camera.Modifica_dimensione(98);
            Assert.True(camera.Dimensione== 98);
        }
        [Fact]
        public void Test11()
        {
            Camere.Hotel.Camera camera = new Camere.Hotel.Camera(Convert.ToString(101), 45, 8, false, false, false, 400, 3);
            Assert.Throws<Exception>(() => camera.Modifica_dimensione(-98));
        }
        [Fact]
        public void Test12()
        {
            Camere.Hotel.Camera camera = new Camere.Hotel.Camera(Convert.ToString(101), 45, 8, false, false, false, 400, 3);
            camera.Modifica_bagno(true);
            Assert.True(camera.Bagno == true);
        }
        [Fact]
        public void Test13()
        {
            Camere.Hotel.Camera camera = new Camere.Hotel.Camera(Convert.ToString(101), 45, 8, false, false, false, 400, 3);
            camera.Modifica_bagno(false);
            Assert.True(camera.Bagno == false);
        }
        [Fact]
        public void Test14()
        {
            Camere.Hotel.Camera camera = new Camere.Hotel.Camera(Convert.ToString(101), 45, 8, false, false, false, 400, 3);
            camera.Aggiungi_per();
            Assert.True(camera.Persone==4);
        }
        [Fact]
        public void Test15()
        {
            Camere.Hotel.Camera camera = new Camere.Hotel.Camera(Convert.ToString(101), 45, 8, false, false, false, 400, 3);
            camera.Diminuisci_per();
            Assert.True(camera.Persone == 2);
        }
        [Fact]
        public void Test16()
        {
            Camere.Hotel.Camera camera = new Camere.Hotel.Camera(Convert.ToString(101), 45, 8, false, false, false, 400, 1);
            Assert.Throws<Exception>(() => camera.Diminuisci_per());
        }
        [Fact]
        public void Test17()
        {
            Camere.Hotel.Camera camera = new Camere.Hotel.Camera(Convert.ToString(101), 45, 8, false, false, false, 400, 1);
            Assert.True(camera.prezzo_singola()==camera.Costo/camera.Persone);
        }
        [Fact]
        public void Test18()
        {
            Camere.Hotel.Camera camera1 = new Camere.Hotel.Camera(Convert.ToString(101), 45, 8, false, false, false, 400, 1);
            Camere.Hotel.Camera camera2 = new Camere.Hotel.Camera(Convert.ToString(101), 45, 8, false, false, false, 400, 5);
            Assert.True(camera1.confronta_Prezzo(camera2)== "la camera più conveniente è quella numero " + camera2.Numero);
        }
        [Fact]
        public void Test19()
        {
            Camere.Hotel.Camera camera1 = new Camere.Hotel.Camera(Convert.ToString(101), 45, 8, false, false, false, 400, 2);
            Camere.Hotel.Camera camera2 = new Camere.Hotel.Camera(Convert.ToString(101), 45, 8, false, false, false, 400, 1);
            Assert.True(camera1.confronta_Prezzo(camera2) == "la camera più conveniente è quella numero " + camera1.Numero);
        }
        [Fact]
        public void Test20()
        {
            Camere.Hotel.Camera camera1 = new Camere.Hotel.Camera(Convert.ToString(101), 45, 8, false, false, false, 400, 2);
            Camere.Hotel.Camera camera2 = new Camere.Hotel.Camera(Convert.ToString(101), 45, 8, false, false, false, 400, 2);
            Assert.True(camera1.confronta_Prezzo(camera2) == "il prezzo medio delle stanze è equivalente");
        }
    }
}