using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PerformanceLogger : MonoBehaviour
{
    public float logInterval = 1.0f; // Time interval between logs (in seconds)
    private List<string> logData = new List<string>(); // List to store performance logs
    private string filePath; // Path to save the CSV file

    void Start()
    {
        // Save file to Desktop for simplicity
        filePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop), "PerformanceLog2f_tooMuchData.csv");

        Debug.Log("Saving log to: " + filePath);

        // Write the header row
        logData.Add("Time (s),FPS,CPU Time (ms),GPU Time (ms),Memory Usage (MB)");

        // Start the logging process
        //StartCoroutine(LogPerformance());
    }
    public void StartLogging()
    {
        StartCoroutine(LogPerformance());
    }
    public void StopLogging()
    {
        StopCoroutine(LogPerformance());
        //save the log
        try
        {
            File.WriteAllLines(filePath, logData.ToArray());
            Debug.Log("Performance log saved to: " + filePath);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error saving log: " + e.Message);
        }
    }

    IEnumerator LogPerformance()
    {
        while (true)
        {
            yield return new WaitForSeconds(logInterval);

            // Capture the performance data
            float fps = 1.0f / Time.deltaTime; // Frames per second
            float cpuTime = Time.smoothDeltaTime * 1000.0f; // CPU time in milliseconds
            float gpuTime = Time.deltaTime * 1000.0f; // GPU time approximation (if GPU profiler unavailable)
            float memoryUsage = UnityEngine.Profiling.Profiler.GetTotalAllocatedMemoryLong() / (1024f * 1024f); // Memory in MB

            // Record the current time
            float time = Time.time;

            // Add the data to the log
            string logEntry = $"{time:F2},{fps:F2},{cpuTime:F2},{gpuTime:F2},{memoryUsage:F2}";
            logData.Add(logEntry);

            Debug.Log("Performance Log: " + logEntry);
        }
    }

    // Save the log to a CSV file when user presses the Z key
   /* void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            try
            {
                File.WriteAllLines(filePath, logData.ToArray());
                Debug.Log("Performance log saved to: " + filePath);
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error saving log: " + e.Message);
            }
        }
    }*/
}
