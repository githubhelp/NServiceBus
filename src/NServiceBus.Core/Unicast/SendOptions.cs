namespace NServiceBus.Unicast
{
    using System;
    using System.ComponentModel;


    [Obsolete("This is a prototype API. May change in minor version releases.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SendOptions
    {
        public SendOptions()
        {
            Intent = MessageIntentEnum.Send;
            EnforceMessagingBestPractices = true;
        }

        public SendOptions(Address destination):this()
        {
            Destination = destination;
        }

        public SendOptions(string destination): this(Address.Parse(destination))
        {
        }

        public MessageIntentEnum Intent { get; set; }
        public Address Destination { get; set; }
        public string CorrelationId { get; set; }
        public Address ReplyToAddress { get; set; }
        public DateTime? DeliverAt { get; set; }
        public TimeSpan? DelayDeliveryWith { get; set; }
        public bool EnforceMessagingBestPractices { get; set; }


        public static SendOptions ReplyTo(Address replyToAddress)
        {
            if (replyToAddress == null)
                throw new InvalidOperationException("Can't reply with null reply-to-address field. It can happen if you are using a SendOnly client. See http://particular.net/articles/one-way-send-only-endpoints");

            return new SendOptions(replyToAddress){Intent = MessageIntentEnum.Reply};
        }
    }
}