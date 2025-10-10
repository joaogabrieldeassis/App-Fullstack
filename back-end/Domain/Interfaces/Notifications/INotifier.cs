using Domain.Notifications;

namespace Domain.Interfaces.Notifications;

public interface INotifier
{
    bool HasNotification();
    List<Notification> GetNotifications();
    void Handle(Notification notification);
}