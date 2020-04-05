using System.Collections.ObjectModel;

namespace EHI.WebSite.Areas.HelpPage.ModelDescriptions {
    public class EnumTypeModelDescription : ModelDescription {
        public EnumTypeModelDescription() {
            Patients = new Collection<EnumValueDescription>();
        }

        public Collection<EnumValueDescription> Patients { get; private set; }
    }
}