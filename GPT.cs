using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChatFusion
{
    internal class GPT
    {
        public static string GetApiKey()
        {
            // Try to get the API key from environment variables
            string apiKey = Properties.Settings.Default.apiKey;

            // If the API key is not set, prompt the user to enter it
            while (string.IsNullOrEmpty(apiKey))
            {
                apiKey = Microsoft.VisualBasic.Interaction.InputBox("Please enter your OpenAI API Key:", "API Key Required");

                // If the user cancels the prompt without entering an API key, exit the application
                if (string.IsNullOrEmpty(apiKey))
                {
                    MessageBox.Show("API key is required to use this application.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Application.Current.Shutdown();
                }

                // Save the API key as an environment variable for future use
                Properties.Settings.Default.apiKey = apiKey;
                Properties.Settings.Default.Save();
            }

            return apiKey;
        }

        internal static void ClearAPIKey()
        {
            Properties.Settings.Default.apiKey = "";
            Properties.Settings.Default.Save();
        }
    }
}
