public class MeatPiece
{
	public MeatSpecies meatSpecies;
	public CuttingSize cuttingResult;
	public CuttingJudgement cuttingJudgement;

	public MeatPiece(MeatSpecies species, CuttingSize cuttingResult)
	{
		this.meatSpecies = species;
		this.cuttingResult = cuttingResult;
	}
}