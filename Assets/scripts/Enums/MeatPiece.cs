public class MeatPiece
{
	public MeatSpecies meatSpecies;
	public CuttingResult cuttingResult;

	public MeatPiece(MeatSpecies species, CuttingResult cuttingResult)
	{
		this.meatSpecies = species;
		this.cuttingResult = cuttingResult;
	}
}