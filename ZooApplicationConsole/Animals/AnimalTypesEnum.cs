using System.ComponentModel;

namespace ZooApplicationConsole.Animals
{
    public enum AnimalTypesEnum
    {
        [Description("Амфибия")] Amphibian,
        [Description("Птица")] Bird,
        [Description("Рыба")] Fish,
        [Description("Беспозвоночное")] Invertebrate,
        [Description("Млекопитающее")] Mammals,
        [Description("Рептилия")] Reptiles
    }
}
