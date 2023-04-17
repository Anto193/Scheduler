using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Diagnostics;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class Form1 : Form
    {
        int anzahlProzesse;
        public Form1()
        {
            InitializeComponent();
        }
        private void auswahlScheduler_SelectedIndexChanged(object sender, EventArgs e)
        {
            speicherAuswahl.Enabled = true;
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void speicherAnzProzesse_Click(object sender, EventArgs e)
        {
            // Hole die Anzahl der Prozesse aus der ComboBox
            anzahlProzesse = (int)numProzesse.Value;

            // Deaktiviere Anzahl Prozesse
            numProzesse.Enabled = false;

            // Erstelle eine Liste von Prozessen
            List<Process> processesList = new List<Process>();

            // Schleife durch jeden Prozess und fordere den Benutzer auf, eine BurstTime einzugeben
            for (int i = 1; i <= anzahlProzesse; i++)
            {
                // Fordere den Benutzer auf, eine BurstTime einzugeben
                int burstTime = 0;
                int arrivalTime = 0;
                bool validInput = false;
                while (!validInput)
                {
                    // Eingabefenster für BurstTime und Ankunftszeit anzeigen und Eingaben speichern
                    string burstTimeString = Microsoft.VisualBasic.Interaction.InputBox("Bitte geben Sie die BurstTime für Prozess " + i + " ein:", "BurstTime");
                    string arrivalTimeString = Microsoft.VisualBasic.Interaction.InputBox("Bitte geben Sie die Ankunftszeit für Prozess " + i + " ein:", "Ankunftszeit");
                    if (int.TryParse(burstTimeString, out burstTime) && int.TryParse(arrivalTimeString, out arrivalTime) && burstTime >= 1)
                    {
                        validInput = true;
                    }
                    else
                    {
                        MessageBox.Show("Ungültige Eingabe. Bitte geben Sie eine positive ganze Zahl größer als 0 ein.", "Fehler");
                    }
                }

                // Erstelle den Prozess mit der BurstTime und füge ihn der Liste hinzu
                Process process = new Process(i, burstTime, arrivalTime);
                processesList.Add(process);
            }

            switch (auswahlScheduler.Text)
            {
                case "First Come First Serve":
                    RunFCFS(processesList);
                    break;
                case "Shortest Job First":
                    RunSJF(processesList);
                    break;
                case "Round Robin":
                    int zeitWert = erzeugeZeitscheibe();
                    RunRoundRobin(processesList, zeitWert);
                    break;
                default:
                    break;
            }
            anzProzesseText.Visible = false;

        }
        private void speicherAuswahl_Click(object sender, EventArgs e)
        {
            Controls.Remove(speicherAuswahl);
            speicherAnzProzesse.Visible = true;
            auswahlScheduler.Enabled = false;
            numProzesse.Visible = true;
            auswahlText.Visible = false;
            anzProzesseText.Visible = true;
        }

        // Funktion zum Ausführen des FCFS-Schedulers
        private void RunFCFS(List<Process> processesList)
        {
            List<string> executionOrder = new List<string>();
            int time = 0;
            int waitingTime = 0;
            foreach (Process process in processesList.OrderBy(p => p.ArrivalTime))
            {
                if (process.ArrivalTime > time)
                {
                    time = process.ArrivalTime;
                }
                waitingTime += time - process.ArrivalTime;
                executionOrder.Add("Prozess " + process.ID + ": " + (time - process.ArrivalTime) + " ms Wartezeit, " + process.BurstTime + " ms Ausführungszeit, " + process.ArrivalTime + " ms Ankunftszeit, " + (process.BurstTime + time) + " ms Endzeit.");
                time += process.BurstTime;
            }

            // Ergebnis als MessageBox ausgeben
            string message = "Durchschnittliche Wartezeit: " + (double)waitingTime / processesList.Count;
            message += "\n\nReihenfolge der Ausführung:\n" + string.Join("\n", executionOrder);
            message += "\n\nMöchten Sie das Programm neu starten?";
            DialogResult restart = MessageBox.Show(message, "Ergebnis", MessageBoxButtons.YesNo);
            if (restart == DialogResult.Yes)
            {
                Application.Restart();
            }
            else
            {
                Application.Exit();
            }
        }

        // Funktion zum Ausführen des Round-Robin-Schedulers
        private void RunRoundRobin(List<Process> processList, int quantum)
        {
            // Kopie der Prozessliste erstellen
            List<Process> processes = new List<Process>(processList);

            // Variable zur Aufzeichnung der Reihenfolge der Prozessausführung
            List<string> executionOrder = new List<string>();

            // Schleife zur Ausführung der Prozesse
            int time = 0;
            while (processes.Count > 0)
            {
                Process currentProcess = processes[0];
                processes.RemoveAt(0);

                // Wenn die Ankunftszeit des Prozesses größer als die aktuelle Zeit ist, warte bis der Prozess eintrifft
                if (currentProcess.ArrivalTime > time)
                {
                    time = currentProcess.ArrivalTime;
                }

                // Führe den Prozess aus und aktualisiere die Ausführungszeit
                int executionTime = Math.Min(quantum, currentProcess.BurstTime);
                currentProcess.BurstTime -= executionTime;
                executionOrder.Add("Prozess " + currentProcess.ID + ": " + executionTime + " ms ausgeführt.");

                // Füge den Prozess zur Liste der Prozesse hinzu, die noch nicht abgeschlossen sind, wenn er noch Zeit benötigt
                if (currentProcess.BurstTime > 0)
                {
                    processes.Add(currentProcess);
                }

                // Aktualisiere die aktuelle Zeit
                time += executionTime;
            }

            // Ergebnis als MessageBox ausgeben
            string message = "Reihenfolge der Ausführung:\n" + string.Join("\n", executionOrder);
            message += "\n\nMöchten Sie das Programm neu starten?";
            DialogResult restart = MessageBox.Show(message, "Ergebnis", MessageBoxButtons.YesNo);
            if (restart == DialogResult.Yes)
            {
                Application.Restart();
            }
            else
            {
                Application.Exit();
            }
        }

        public void RunSJF(List<Process> processes)
        {
            // Sortiere die Prozesse nach steigender Burstzeit
            processes.Sort((a, b) => a.BurstTime.CompareTo(b.BurstTime));

            int currentTime = 0;
            List<Process> completedProcesses = new List<Process>();

            while (processes.Count > 0)
            {
                // Finde den Prozess mit der kürzesten Burstzeit
                Process currentProcess = processes[0];
                processes.RemoveAt(0);

                // Aktualisiere die Wartezeit und die Verweildauer des aktuellen Prozesses
                currentProcess.WaitingTime = currentTime - currentProcess.ArrivalTime;
                currentProcess.TurnaroundTime = currentProcess.WaitingTime + currentProcess.BurstTime;

                // Füge den aktuellen Prozess zur Liste der abgeschlossenen Prozesse hinzu
                completedProcesses.Add(currentProcess);

                // Aktualisiere die aktuelle Zeit
                currentTime += currentProcess.BurstTime;
            }

            // Zeige die Ergebnisse in einer MessageBox an
            string results = "SJF Scheduling Ergebnisse:\n";
            foreach (Process p in completedProcesses)
            {
                results += "Prozess " + p.ID + ": " + p.ArrivalTime + " ms Ankunftszeit, " + p.BurstTime + " ms Ausführungszeit. \n";
            }
            results += "\n\nMöchten Sie das Programm neu starten?";
            DialogResult restart = MessageBox.Show(results, "Ergebnis", MessageBoxButtons.YesNo);
            if (restart == DialogResult.Yes)
            {
                Application.Restart();
            }
            else
            {
                Application.Exit();
            }
        }

        public int erzeugeZeitscheibe()
        {
            int quantumTime = 0;
            bool validTime = false;
            while(!validTime)
            {
                string quantumTimeString = Microsoft.VisualBasic.Interaction.InputBox("Bitte geben Sie einen Wert für die Zeitscheibe ein.", "Zeitscheibenwert");
                if (int.TryParse(quantumTimeString, out quantumTime) && quantumTime >= 1)
                    validTime = true;
                else
                    MessageBox.Show("Ungültige Eingabe. Bitte geben Sie eine positive ganze Zahl größer als 0 ein.\", \"Fehler");
            }
            return quantumTime;
        }

        private void numProzesse_ValueChanged(object sender, EventArgs e)
        {
            if(numProzesse.Value >= 1)
                speicherAnzProzesse.Enabled = true;
            else
                speicherAnzProzesse.Enabled = false;
        }
    }

    public class Process
    {
        // Eigenschaften
        public int ID { get; set; }
        public int BurstTime { get; set; }
        public int ArrivalTime { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public int TurnaroundTime { get; set; }
        public int WaitingTime { get; set; }

        // Konstruktor
        public Process(int id, int burstTime, int arrivalTime)
        {
            ID = id;
            BurstTime = burstTime;
            ArrivalTime = arrivalTime;
            StartTime = 0;
            EndTime = 0;
            TurnaroundTime = 0;
            WaitingTime = 0;
        }
    }
}