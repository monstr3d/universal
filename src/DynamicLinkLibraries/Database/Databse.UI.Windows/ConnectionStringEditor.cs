using Database.UI.Intrerfaces;

namespace Database.UI.Windows
{
    public class ConnectionStringEditor : IConnectionStringEditor
    {
        FormConnectionString form;

        CancellationTokenSource token;

        List<string> strings;

        string connectionString;

        public ConnectionStringEditor(List<string> strings)
        {
            this.strings = strings == null ? new List<string>() : strings;  
        }

        void IConnectionStringEditor.Close()
        {
            if (form != null) 
            {
                if (!form.IsDisposed)
                {
                    form.Close();
                }
            }
            form = null;
        }

        void Action()
        {
            if (form == null || form.IsDisposed)
            {
                form = null;
                form = new FormConnectionString(strings, connectionString);
                form.Show();
                form.BringToFront();
            }
            form.Token = token;
            

        }

        Control Control => StaticExtensionDatabaseUIWindows.Control;

        async Task<string> Get(string cs)
        {
            Control.Invoke(() => {
                token = new CancellationTokenSource();
                if (form == null || form.IsDisposed)
                {
                    form = null;
                    form = new FormConnectionString(strings, connectionString);
                    form.Show();
                    form.BringToFront();
                }
                form.Token = token;
            });
            var t = Task.Delay(int.MaxValue, token.Token);
            await t;
            return form.ConnectionString;
        }

        string IConnectionStringEditor.ConnectionStrig(string connectionString)
        {
            if (form == null || form.IsDisposed)
            {
                form = null;
                form = new FormConnectionString(strings, connectionString);
            }
            form.ShowDialog(Control);
            return form.ConnectionString;

        }
    }
}

