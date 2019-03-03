using System.ComponentModel;

namespace NowMineCommon.Models
{
    public class BaseUser : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public int Id { get; set; }
        private byte[] _color;

        public event PropertyChangedEventHandler PropertyChanged;

        public byte[] ColorBytes
        {
            get
            {
                if (_color == null)
                    _color = new byte[3];
                return _color;
            }

            set
            {
                _color = value;
                OnPropertyChanged(nameof(ColorBytes));
            }
        }

        protected virtual void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
