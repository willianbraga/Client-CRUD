using System.Collections.Generic;
using System.Linq;

namespace CRUD.Domain.Utils.Validations
{
    public abstract class Notifiable
    {
        private readonly List<Notification> _notifications;
        public bool Invalid => _notifications.Any() || GetNotificationFromValidation().Any();
        public bool Valid => !Invalid;

        protected Notifiable()
        {
            _notifications = new List<Notification>();
        }

        public IReadOnlyCollection<Notification> Notifications =>
            new List<Notification>(_notifications).Concat(GetNotificationFromValidation()).ToList();

        protected virtual IEnumerable<Notification> Validation() => null;

        private IEnumerable<Notification> GetNotificationFromValidation()
        {
            return Validation() ?? new List<Notification>();
        }

        public void AddNotification(string property, string message)
        {
            _notifications.Add(new Notification(property, message));
        }

        public void AddNotifications(IReadOnlyCollection<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }
        public void AddNotifications(Notifiable item)
        {
            AddNotifications(item.Notifications);
        }
    }
}