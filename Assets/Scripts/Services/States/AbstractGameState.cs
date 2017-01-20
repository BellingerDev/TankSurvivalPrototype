namespace iLogos.TankSurvival
{
	public abstract class AbstractGameState 
	{
		public abstract void Prepare();
		public abstract void Update();
		public abstract void Finish();
	}
}
