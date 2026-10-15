using System;
using System.Collections.Generic;

public class Karyawan
{
    public string Nama { get; set; }
    public double Gaji { get; set; }

    public Karyawan(string nama, double gaji)
    {
        Nama = nama;
        Gaji = gaji;
    }

    public virtual void Kerja()
    {
        Console.WriteLine($"{Nama} sedang bekerja.");
    }

    public virtual void InfoKaryawan()
    {
        Console.WriteLine($"Nama: {Nama}, Gaji: {Gaji}");
    }
}

public class Tetap : Karyawan
{
    public double Tunjangan { get; set; }

    public Tetap(string nama, double gaji, double tunjangan)
        : base(nama, gaji)
    {
        Tunjangan = tunjangan;
    }

    public double HitungGajiTotal()
    {
        return Gaji + Tunjangan;
    }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} (Karyawan Tetap) sedang bekerja.");
    }

    public override void InfoKaryawan()
    {
        Console.WriteLine($"Nama: {Nama}, Gaji: {Gaji}, Tunjangan: {Tunjangan}, Total: {HitungGajiTotal()}");
    }
}

public class Kontrak : Karyawan
{
    public int Durasi { get; set; }

    public Kontrak(string nama, double gaji, int durasi)
        : base(nama, gaji)
    {
        Durasi = durasi;
    }

    public void CekKontrak()
    {
        Console.WriteLine($"{Nama} memiliki kontrak selama {Durasi} bulan.");
    }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} (Karyawan Kontrak) sedang bekerja.");
    }

    public override void InfoKaryawan()
    {
        Console.WriteLine($"Nama: {Nama}, Gaji: {Gaji}, Durasi: {Durasi} bulan");
    }
}

public class Manager : Tetap
{
    public Manager(string nama, double gaji, double tunjangan)
        : base(nama, gaji, tunjangan) { }

    public void Memimpin()
    {
        Console.WriteLine($"{Nama} sedang memimpin rapat.");
    }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} (Manager) sedang mengatur strategi perusahaan.");
    }
}

public class Staff : Tetap
{
    public Staff(string nama, double gaji, double tunjangan)
        : base(nama, gaji, tunjangan) { }

    public void KerjakanTugas()
    {
        Console.WriteLine($"{Nama} sedang mengerjakan tugas harian.");
    }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} (Staff) sedang menyelesaikan pekerjaan.");
    }
}

public class Magang : Kontrak
{
    public Magang(string nama, double gaji, int durasi)
        : base(nama, gaji, durasi) { }

    public void Belajar()
    {
        Console.WriteLine($"{Nama} sedang belajar hal baru.");
    }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} (Magang) sedang membantu pekerjaan sambil belajar.");
    }
}

public class Freelancer : Kontrak
{
    public Freelancer(string nama, double gaji, int durasi)
        : base(nama, gaji, durasi) { }

    public void AmbilProyek()
    {
        Console.WriteLine($"{Nama} sedang mengambil proyek baru.");
    }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} (Freelancer) sedang mengerjakan proyek klien.");
    }
}

public class Perusahaan
{
    private List<Karyawan> daftarKaryawan = new List<Karyawan>();

    public void TambahKaryawan(Karyawan karyawan)
    {
        daftarKaryawan.Add(karyawan);
    }

    public void DaftarKaryawan()
    {
        Console.WriteLine("Daftar Karyawan Perusahaan");
        foreach (var k in daftarKaryawan)
        {
            k.InfoKaryawan();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Perusahaan perusahaan = new Perusahaan();

        Manager manager = new Manager("Dava", 10000000, 5000000);
        Staff staff = new Staff("Felix", 5000000, 1000000);
        Magang magang = new Magang("Jericho", 2000000, 6);
        Freelancer freelancer = new Freelancer("Julian", 8000000, 3);

        perusahaan.TambahKaryawan(manager);
        perusahaan.TambahKaryawan(staff);
        perusahaan.TambahKaryawan(magang);
        perusahaan.TambahKaryawan(freelancer);
        perusahaan.DaftarKaryawan();

        Console.WriteLine("\nDemonstrasi Polymorphism");
        List<Karyawan> semuaKaryawan = new List<Karyawan> { manager, staff, magang, freelancer };
        foreach (var k in semuaKaryawan)
        {
            k.Kerja();
        }

        Console.WriteLine("\nMethod Khusus");
        manager.Memimpin();
        staff.KerjakanTugas();
        magang.Belajar();
        freelancer.AmbilProyek();
        magang.CekKontrak();
    }
}