namespace UIAndOthers {
  public static class StaticWinner {
    private static int _winner;

    public static int Winner {
      get { return _winner; }
      set { _winner = value; }
    }
  }
}