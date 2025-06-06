using System;
using System.Collections.Generic;

namespace HospitalAIS
{
    class Program
    {
        static List<Patient> patients = new List<Patient>();
        static List<Doctor> doctors = new List<Doctor>();
        static List<Appointment> appointments = new List<Appointment>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n=== АИС Больницы ===");
                Console.WriteLine("1. Добавить пациента");
                Console.WriteLine("2. Добавить врача");
                Console.WriteLine("3. Назначить прием");
                Console.WriteLine("4. Показать всех пациентов");
                Console.WriteLine("5. Показать всех врачей");
                Console.WriteLine("6. Показать все приемы");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddPatient(); break;
                    case "2": AddDoctor(); break;
                    case "3": CreateAppointment(); break;
                    case "4": ShowPatients(); break;
                    case "5": ShowDoctors(); break;
                    case "6": ShowAppointments(); break;
                    case "0": return;
                    default: Console.WriteLine("Неверный выбор."); break;
                }
            }
        }

        static void AddPatient()
        {
            Console.Write("Введите имя пациента: ");
            string name = Console.ReadLine();
            Console.Write("Введите возраст пациента: ");
            int age = int.Parse(Console.ReadLine());

            patients.Add(new Patient { Name = name, Age = age });
            Console.WriteLine("Пациент добавлен.");
        }

        static void AddDoctor()
        {
            Console.Write("Введите имя врача: ");
            string name = Console.ReadLine();
            Console.Write("Введите специальность врача: ");
            string specialization = Console.ReadLine();

            doctors.Add(new Doctor { Name = name, Specialization = specialization });
            Console.WriteLine("Врач добавлен.");
        }

        static void CreateAppointment()
        {
            if (patients.Count == 0 || doctors.Count == 0)
            {
                Console.WriteLine("Сначала добавьте пациентов и врачей.");
                return;
            }

            Console.WriteLine("Выберите пациента:");
            for (int i = 0; i < patients.Count; i++)
                Console.WriteLine($"{i + 1}. {patients[i].Name}");

            int patientIndex = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Выберите врача:");
            for (int i = 0; i < doctors.Count; i++)
                Console.WriteLine($"{i + 1}. {doctors[i].Name} ({doctors[i].Specialization})");

            int doctorIndex = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Введите дату приема (дд.мм.гггг): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            appointments.Add(new Appointment
            {
                Patient = patients[patientIndex],
                Doctor = doctors[doctorIndex],
                Date = date
            });

            Console.WriteLine("Прием назначен.");
        }

        static void ShowPatients()
        {
            Console.WriteLine("\n--- Пациенты ---");
            foreach (var p in patients)
                Console.WriteLine($"Имя: {p.Name}, Возраст: {p.Age}");
        }

        static void ShowDoctors()
        {
            Console.WriteLine("\n--- Врачи ---");
            foreach (var d in doctors)
                Console.WriteLine($"Имя: {d.Name}, Специальность: {d.Specialization}");
        }

        static void ShowAppointments()
        {
            Console.WriteLine("\n--- Приемы ---");
            foreach (var a in appointments)
                Console.WriteLine($"Дата: {a.Date.ToShortDateString()}, Пациент: {a.Patient.Name}, Врач: {a.Doctor.Name}");
        }
    }

    class Patient
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Doctor
    {
        public string Name { get; set; }
        public string Specialization { get; set; }
    }

    class Appointment
    {
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime Date { get; set; }
    }
}
