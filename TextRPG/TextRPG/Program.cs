using System;
using System.Threading;
using textRPG.enemies;
using TextRPG.equipment;


namespace textRPG
{
    class Program
    {



        static void Main(string[] args)
        {
            float playerHp = 0;
            float playerMaxHp = 0;
            float playerDef = 0;
            float playerMinDmg = 0;
            float playerMaxDmg = 0;
            float playerDmg = 0;


            int battle = 0;
            bool end = false;
            bool battleChoice = false;
            int battleActionChoice = 0;
            bool isBattleActive = true;
            bool sleeping = false;
            bool death = false;
            bool shopActive = false;
            bool weaponStats = true;
            string shopMainMenuChoices = "";

            bool equipmentStats = false;
            int ratBattle = 0;
            int xpGain = 0;
            int coinGain = 0;
            float defenseFormula = 0;
            Random defenseFormulaRandomize = new Random();
            Random dmgRnd = new Random();
            Random runChanceRandom = new Random();

            #region enemy declarations
            #region rat declarations
            Rat ratLevel1 = new Rat("rat level 1", 15, 2, 0.5f, 0);
            Rat ratLevel2 = new Rat("rat level 2", 25, 3, 1, 0);
            Rat eliteRat = new Rat("elite rat", 50, 5, 2, 0);
            Rat bossRat = new Rat("rat king", 100, 10, 5, 0);
            ratLevel1.maxHealth = ratLevel1.health;
            ratLevel2.maxHealth = ratLevel2.health;
            eliteRat.maxHealth = eliteRat.health;
            bossRat.maxHealth = bossRat.health;
            #endregion
            #region wolf declarations
            Wolf wolf = new Wolf("wolf", 100, 5, 4, 0);
            Wolf alphaWolf = new Wolf("alpha wolf", 500, 12, 12, 0);
            Wolf wolfPack = new Wolf("wolf pack", 500, 25, 20, 0);
            Wolf wolfPack2 = new Wolf("pack of 12 wolves", 1200, 60, 48, 0);
            Wolf wolfKing = new Wolf("wolf king", 3500, 12, 12, 0);
            Wolf alphaWolfPack = new Wolf("pack of alpha wolves", 2000, 48, 48, 0);

            #endregion wolf declarations




            #endregion enemy declarations

            #region equipment

            #region Helmets
            //helmets (name, price, equiped,  hp, dmg, def, dex, lck)
            Equipment.Helmet leatherHelmet = new Equipment.Helmet("Leather Helmet", 15, false, 1, 1, 1, 0, 0);
            Equipment.Helmet copperHelmet = new Equipment.Helmet("Copper Helmet", 30, false, 1.5f, 1.5f, 1.5f, 0, 0);
            Equipment.Helmet bronzeHelmet = new Equipment.Helmet("Bronze Helmet", 50, false, 2, 2, 2, 0, 0);
            Equipment.Helmet ironHelmet = new Equipment.Helmet("Iron Helmet", 75, false, 3, 3, 3, 0, 0);
            Equipment.Helmet steelHelmet = new Equipment.Helmet("Steel Helmet", 125, false, 5, 5, 5, 0, 0);
            Equipment.Helmet dwarvenHelmet = new Equipment.Helmet("Dwarven Helmet", 250, false, 7.5f, 7.5f, 7.5f, 0, 0);
            Equipment.Helmet orcishHelmet = new Equipment.Helmet("Orcish Helmet", 400, false, 10, 10, 10, 0, 0);
            Equipment.Helmet steelOrcishHelmet = new Equipment.Helmet("Steel-reinforced Orcish Helmet", 500, false, 12, 12, 12, 0, 0);
            Equipment.Helmet ebonyHelmet = new Equipment.Helmet("Ebony Helmet", 750, false, 15, 15, 15, 0, 0);
            Equipment.Helmet dragonBoneHelmet = new Equipment.Helmet("Dragon bone Helmet", 1500, false, 18, 18, 18, 0, 0);
            Equipment.Helmet teathriumHelmet = new Equipment.Helmet("Teathrium Helmet", 2500, false, 25, 25, 25, 0, 0);
            Equipment.Helmet dragonplateHelmet = new Equipment.Helmet("Dragon plate Helmet", 3000, false, 30, 30, 30, 0, 0);
            Equipment.Helmet ancientTeathriumHelmet = new Equipment.Helmet("Ancient Teathrium Helmet", 5000, false, 32, 32, 32, 0, 0);
            Equipment.Helmet demotriumDragonHelmet = new Equipment.Helmet("Demotrium Reinforced Dragon Helmet", 10000, false, 40, 40, 40, 0, 0);

            #endregion Helmets
            #region Chestplates
            Equipment.Chestplate leatherChestplate = new Equipment.Chestplate("Leather Chestplate", 30, false, 2, 2, 2, 0, 0);
            Equipment.Chestplate copperChestplate = new Equipment.Chestplate("Copper Chestplate", 60, false, 3, 3, 3, 0, 0);
            Equipment.Chestplate bronzeChestplate = new Equipment.Chestplate("Bronze Chestplate", 100, false, 4, 4, 4, 0, 0);
            Equipment.Chestplate ironChestplate = new Equipment.Chestplate("Iron Chestplate", 150, false, 6, 6, 6, 0, 0);
            Equipment.Chestplate steelChestplate = new Equipment.Chestplate("Steel Chestplate", 250, false, 10, 10, 10, 0, 0);
            Equipment.Chestplate dwarvenChestplate = new Equipment.Chestplate("Dwarven Chestplate", 500, false, 15, 15, 15, 0, 0);
            Equipment.Chestplate orcishChestplate = new Equipment.Chestplate("Orcish Chestplate", 800, false, 20, 20, 20, 0, 0);
            Equipment.Chestplate steelOrcishChestplate = new Equipment.Chestplate("Steel-reinforced Orcish Chestplate", 1000, false, 24, 24, 24, 0, 0);
            //base price + 200%
            Equipment.Chestplate ebonyChestplate = new Equipment.Chestplate("Ebony Chestplate", 2250, false, 30, 30, 30, 0, 0);
            Equipment.Chestplate dragonBoneChestplate = new Equipment.Chestplate("Dragon bone Chestplate", 4500, false, 36, 36, 36, 0, 0);
            Equipment.Chestplate teathriumChestplate = new Equipment.Chestplate("Teathrium Chestplate", 7500, false, 50, 50, 50, 0, 0);
            Equipment.Chestplate dragonplateChestplate = new Equipment.Chestplate("Dragon plate Chestplate", 9000, false, 60, 60, 60, 0, 0);
            Equipment.Chestplate ancientTeathriumChestplate = new Equipment.Chestplate("Ancient Teathrium Chestplate", 10000, false, 64, 64, 64, 0, 0);
            Equipment.Chestplate demotriumDragonChestplate = new Equipment.Chestplate("Demotrium Reinforced Dragon Chestplate", 20000, false, 80, 80, 80, 0, 0);


            #endregion Chestplates
            #region Gloves
            //appx base price -25%, base value appx -25%
            Equipment.Gloves leatherGloves = new Equipment.Gloves("Leather Gloves", 10, false, 0.75f, 0.75f, 0.75f, 0, 0);
            Equipment.Gloves copperGloves = new Equipment.Gloves("Copper Gloves", 20, false, 1.25f, 1.25f, 1.25f, 0, 0);
            Equipment.Gloves bronzeGloves = new Equipment.Gloves("Bronze Gloves", 35, false, 1.5f, 1.5f, 1.5f, 0, 0);
            Equipment.Gloves ironGloves = new Equipment.Gloves("Iron Gloves", 50, false, 2.25f, 2.25f, 2.25f, 0, 0);
            Equipment.Gloves steelGloves = new Equipment.Gloves("Steel Gloves", 100, false, 3.75f, 3.75f, 3.75f, 0, 0);
            Equipment.Gloves dwarvenGloves = new Equipment.Gloves("Dwarven Gloves", 200, false, 5.5f, 5.5f, 5.5f, 0, 0);
            Equipment.Gloves orcishGloves = new Equipment.Gloves("Orcish Gloves", 300, false, 7.5f, 7.5f, 7.5f, 0, 0);
            Equipment.Gloves steelOrcishGloves = new Equipment.Gloves("Steel-reinforced Orcish Gloves", 375, false, 9, 9, 9, 0, 0);
            Equipment.Gloves ebonyGloves = new Equipment.Gloves("Ebony Gloves", 550, false, 11.25f, 11.25f, 11.25f, 0, 0);
            Equipment.Gloves dragonBoneGloves = new Equipment.Gloves("Dragon bone Gloves", 1200, false, 13.5f, 13.5f, 13.5f, 0, 0);
            Equipment.Gloves teathriumGloves = new Equipment.Gloves("Teathrium Gloves", 2000, false, 18.75f, 18.75f, 18.75f, 0, 0);
            Equipment.Gloves dragonplateGloves = new Equipment.Gloves("Dragon plate Gloves", 2500, false, 22.5f, 22.5f, 22.5f, 0, 0);
            Equipment.Gloves ancientTeathriumGloves = new Equipment.Gloves("Ancient Teathrium Gloves", 3750, false, 24, 24, 24, 0, 0);
            Equipment.Gloves demotriumDragonGloves = new Equipment.Gloves("Demotrium Reinforced Dragon Gloves", 7500, false, 30, 30, 30, 0, 0);



            #endregion Gloves
            #region Leggings
            // appx base price + 25% 
            Equipment.Leggings leatherLeggings = new Equipment.Leggings("Leather Leggings", 20, false, 1.5f, 1.5f, 1.5f, 0, 0);
            Equipment.Leggings copperLeggings = new Equipment.Leggings("Copper Leggings", 40, false, 2.25f, 2.25f, 2.25f, 0, 0);
            Equipment.Leggings bronzeLeggings = new Equipment.Leggings("Bronze Leggings", 60, false, 3, 3, 3, 0, 0);
            Equipment.Leggings ironLeggings = new Equipment.Leggings("Iron Leggings", 100, false, 4.5f, 4.5f, 4.5f, 0, 0);
            Equipment.Leggings steelLeggings = new Equipment.Leggings("Steel Leggings", 160, false, 7.5f, 7.5f, 7.5f, 0, 0);
            Equipment.Leggings dwarvenLeggings = new Equipment.Leggings("Dwarven Leggings", 315, false, 11.25f, 11.25f, 11.25f, 0, 0);
            Equipment.Leggings orcishLeggings = new Equipment.Leggings("Orcish Leggings", 500, false, 15, 15, 15, 0, 0);
            Equipment.Leggings steelOrcishLeggings = new Equipment.Leggings("Steel-reinforced Orcish Leggings", 625, false, 18, 18, 18, 0, 0);
            //base price + 50%
            Equipment.Leggings ebonyLeggings = new Equipment.Leggings("Ebony Leggings", 1200, false, 22.5f, 22.5f, 22.5f, 0, 0);
            Equipment.Leggings dragonBoneLeggings = new Equipment.Leggings("Dragon bone Leggings", 2250, false, 27, 27, 27, 0, 0);
            Equipment.Leggings teathriumLeggings = new Equipment.Leggings("Teathrium Leggings", 3750, false, 37.5f, 37.5f, 37.5f, 0, 0);
            Equipment.Leggings dragonplateLeggings = new Equipment.Leggings("Dragon plate Leggings", 4500, false, 45, 45, 45, 0, 0);
            Equipment.Leggings ancientTeathriumLeggings = new Equipment.Leggings("Ancient Teathrium Leggings", 7500, false, 48, 48, 48, 0, 0);
            Equipment.Leggings demotriumDragonLeggings = new Equipment.Leggings("Demotrium Reinforced Dragon Leggings", 15000, false, 60, 60, 60, 0, 0);




            #endregion Leggings
            #region Boots
            //appx base price -25%, base value appx -25%
            Equipment.Boots leatherBoots = new Equipment.Boots("Leather Boots", 10, false, 0.75f, 0.75f, 0.75f, 0, 0);
            Equipment.Boots copperBoots = new Equipment.Boots("Copper Boots", 20, false, 1.25f, 1.25f, 1.25f, 0, 0);
            Equipment.Boots bronzeBoots = new Equipment.Boots("Bronze Boots", 35, false, 1.5f, 1.5f, 1.5f, 0, 0);
            Equipment.Boots ironBoots = new Equipment.Boots("Iron Boots", 50, false, 2.25f, 2.25f, 2.25f, 0, 0);
            Equipment.Boots steelBoots = new Equipment.Boots("Steel Boots", 100, false, 3.75f, 3.75f, 3.75f, 0, 0);
            Equipment.Boots dwarvenBoots = new Equipment.Boots("Dwarven Boots", 200, false, 5.5f, 5.5f, 5.5f, 0, 0);
            Equipment.Boots orcishBoots = new Equipment.Boots("Orcish Boots", 300, false, 7.5f, 7.5f, 7.5f, 0, 0);
            Equipment.Boots steelOrcishBoots = new Equipment.Boots("Steel-reinforced Orcish Boots", 375, false, 9, 9, 9, 0, 0);
            Equipment.Boots ebonyBoots = new Equipment.Boots("Ebony Boots", 550, false, 11.25f, 11.25f, 11.25f, 0, 0);
            Equipment.Boots dragonBoneBoots = new Equipment.Boots("Dragon bone Boots", 1200, false, 13.5f, 13.5f, 13.5f, 0, 0);
            Equipment.Boots teathriumBoots = new Equipment.Boots("Teathrium Boots", 2000, false, 18.75f, 18.75f, 18.75f, 0, 0);
            Equipment.Boots dragonplateBoots = new Equipment.Boots("Dragon plate Boots", 2500, false, 22.5f, 22.5f, 22.5f, 0, 0);
            Equipment.Boots ancientTeathriumBoots = new Equipment.Boots("Ancient Teathrium Boots", 3750, false, 24, 24, 24, 0, 0);
            Equipment.Boots demotriumDragonBoots = new Equipment.Boots("Demotrium Reinforced Dragon Boots", 7500, false, 30, 30, 30, 0, 0);

            #endregion Boots

            #region Weapons
            #region starter Weapons
            Equipment.Weapons stick = new Equipment.Weapons("stick", 1, 2, 0, 10, false);
            Equipment.Weapons spikedStick = new Equipment.Weapons("spiked stick", 2, 3, 0, 25, false);
            Equipment.Weapons starFists = new Equipment.Weapons("spiked stick", 0, 125, 0, 69420, false);
            #endregion starter Weapons
            #region shortswords

            Equipment.Weapons woodenShortsword = new Equipment.Weapons("wooden shortsword", 1, 3, 0, 50, false);
            Equipment.Weapons copperShortsword = new Equipment.Weapons("copper shortsword", 3, 5, 0, 100, false);
            Equipment.Weapons ironShortsword = new Equipment.Weapons("iron shortsword", 5, 7, 0, 200, false);

            Equipment.Weapons grometumShortsword = new Equipment.Weapons("grometum shortsword", 9, 12, 0, 500, false);
            Equipment.Weapons teathriumShortsword = new Equipment.Weapons("teathrium shortsword", 15, 17, 0, 750, false);
            #endregion shortswords
            #region longswords
            Equipment.Weapons woodenLongsword = new Equipment.Weapons("wooden longsword", 2, 5, 0, 75, false);
            Equipment.Weapons copperLongsword = new Equipment.Weapons("copper longsword", 5, 10, 0, 150, false);
            Equipment.Weapons steelLongsword = new Equipment.Weapons("steel longsword", 10, 16, 0, 600, false);

            Equipment.Weapons grometumLongsword = new Equipment.Weapons("grometum longsword", 14, 18, 0, 900, false);
            Equipment.Weapons ebonyLongsword = new Equipment.Weapons("ebony longsword", 17, 21, 0, 1200, false);
            Equipment.Weapons teathriumLongsword = new Equipment.Weapons("teathrium longsword", 22, 26, 0, 1500, false);
            Equipment.Weapons ancientTeathriumLongsword = new Equipment.Weapons("ancient teathrium longsword", 24, 27, 0, 1750, false);

            Equipment.Weapons imethriumLongsword = new Equipment.Weapons("imethrium longsword", 35, 40, 0, 5000, false);
            Equipment.Weapons lemothrumDragonLongsword = new Equipment.Weapons("lemothrum dragon longsword", 46, 51, 0, 8700, false);
            Equipment.Weapons demotriumDragonLongsword = new Equipment.Weapons("demotrium dragon longsword", 54, 57, 0, 14500, false);
            #endregion longswords
            #region Hammers
            Equipment.Weapons woodHammer = new Equipment.Weapons("wood Hammer", 5, 6, 0, 150, false);
            Equipment.Weapons copperHammer = new Equipment.Weapons("copper Hammer", 10, 11, 0, 250, false);
            Equipment.Weapons ironHammer = new Equipment.Weapons("iron Hammer", 16, 17, 0, 720, false);

            Equipment.Weapons imethriumHammer = new Equipment.Weapons("imethrium Hammer", 41, 42, 0, 5300, false);
            Equipment.Weapons komethitHammer = new Equipment.Weapons("komethit Hammer", 58, 60, 0, 15250, false);
            #endregion Hammers

            #endregion Weapons

            #region Equipment stat Sum
            Equipment equipment = new Equipment("", 0, 0, 0);
            Equipment helmetEquipment = new Equipment("", 0, 0, 0);
            Equipment chestplateEquipment = new Equipment("", 0, 0, 0);
            Equipment glovesEquipment = new Equipment("", 0, 0, 0);
            Equipment.WeaponEquipment weaponEquipment = new Equipment.WeaponEquipment(0, 0);
            #endregion Equipment stat Sum

            #endregion equipment


            #region player
            #region player declaration
            //diff, health, minDmg, maxDmg, def, maxHealth, dex, lck, exp, coins, level
            Player player1 = new Player("easy", 50, 2, 5, 2.5f, 0, 50, 0, 0, 10, 0);
            player1.maxHealth = player1.health;



            #endregion
            playerHp = player1.health;
            playerMaxHp = player1.maxHealth;
            playerDef = player1.defense;
            playerMinDmg = player1.minDmg;
            playerMaxDmg = player1.maxDmg;
            float playerMinDex = player1.dex / 2;

            #endregion player



            Console.WriteLine("Hello Welcome to textRPG\nWhat do you want to do?");


            while (end == false)
            {

                #region equipment calculations
                if (equipmentStats == false)
                {
                    equipment.hp = helmetEquipment.hp + chestplateEquipment.hp + glovesEquipment.hp;
                    equipment.dmg = helmetEquipment.dmg + chestplateEquipment.dmg + glovesEquipment.dmg;
                    equipment.def = helmetEquipment.def + chestplateEquipment.def + glovesEquipment.def;
                    player1.health = playerHp;
                    player1.maxHealth = playerMaxHp;
                    player1.minDmg = playerMinDmg;
                    player1.maxDmg = playerMaxDmg;
                    player1.defense = playerDef;



                    player1.maxHealth += equipment.hp;
                    player1.health += equipment.hp;
                    player1.minDmg += equipment.dmg;
                    player1.maxDmg += equipment.dmg;
                    player1.defense += equipment.def;
                    equipmentStats = true;
                }

                if (weaponStats == false)
                {
                    player1.minDmg = playerMinDmg;
                    player1.maxDmg = playerMaxDmg;
                    player1.minDmg += weaponEquipment.minDmg;
                    player1.maxDmg += weaponEquipment.maxDmg;
                    weaponStats = true;
                }
                #endregion equipment calculations



                #region death function
                if (death)
                {
                    isBattleActive = false;
                    battleChoice = true;

                    Console.Clear();
                    Console.WriteLine("you died, better luck next time\npress escape to exit the game");
                    Console.ReadKey();
                    Thread.Sleep(500);
                    Environment.Exit(0);
                }
                #endregion death function
                #region menu
                #region menu choices
                Console.WriteLine("\n1:choose game difficulty\n2:battle\n3:show player info\n4:enter shop\n5:sleep(regenerate hp)\n6:exit textRPG");
                string menuChoices = "";
                menuChoices = Console.ReadLine();


                #endregion menu choices
                #region menu choices switch
                switch (menuChoices)
                {
                    case "1":

                        #region difficulty
                        #region difficulty choice

                        bool difficultyChoice = false;
                        while (difficultyChoice == false)
                        {
                            string difficulty = "";
                            Console.Clear();
                            Console.WriteLine("1:Easy\n2:Medium\n3:Hard\n4:back to main menu");
                            difficulty = Console.ReadLine();

                            #endregion //difficulty choice
                            #region difficulty switch
                            switch (difficulty)
                            {
                                case "1":
                                    player1.gameDifficulty = "easy";
                                    player1.DifficultyFunction();
                                    playerHp = player1.health;
                                    playerMaxHp = player1.maxHealth;
                                    playerDef = player1.defense;
                                    playerMinDmg = player1.minDmg;
                                    playerMaxDmg = player1.maxDmg;

                                    equipmentStats = false;
                                    weaponStats = false;



                                    difficultyChoice = true;
                                    break;
                                case "2":
                                    player1.gameDifficulty = "medium";
                                    player1.DifficultyFunction();
                                    playerHp = player1.health;
                                    playerMaxHp = player1.maxHealth;
                                    playerDef = player1.defense;
                                    playerMinDmg = player1.minDmg;
                                    playerMaxDmg = player1.maxDmg;

                                    equipmentStats = false;
                                    weaponStats = false;

                                    difficultyChoice = true;
                                    break;
                                case "3":
                                    player1.gameDifficulty = "hard";
                                    player1.DifficultyFunction();
                                    playerHp = player1.health;
                                    playerMaxHp = player1.maxHealth;
                                    playerDef = player1.defense;
                                    playerMinDmg = player1.minDmg;
                                    playerMaxDmg = player1.maxDmg;

                                    equipmentStats = false;
                                    weaponStats = false;

                                    difficultyChoice = true;
                                    break;
                                case "4":
                                    Console.Clear();
                                    difficultyChoice = true;
                                    break;
                                default:
                                    Console.WriteLine("error difficulty not found");
                                    Thread.Sleep(2000);
                                    break;
                            }
                        }
                        #endregion //difficulty switch
                        #endregion difficulty
                        break;
                    case "2":
                        BattleFunction();
                        break;

                    case "3":

                        #region Player info
                        Console.Clear();
                        PrintOutPlayerInfo();
                        #endregion Player info
                        break;
                    case "4":
                        #region Shop
                        Shop();


                        #endregion Shop
                        break;
                    case "5":
                        Sleep();
                        break;
                    case "6":
                        Thread.Sleep(1000);
                        end = true;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine($"error choice {menuChoices} not found, please try again");
                        break;

                }
                #endregion menu choices switch
                #endregion menu
            }


            void Sleep()
            {
                #region sleeping system
                Console.Clear();
                sleeping = true;
                Console.WriteLine("Sleeping........");
                while (sleeping)
                {
                    Thread.Sleep(500);
                    //regeneration calculation
                    if (player1.maxHealth == player1.health)
                    {
                        player1.health = player1.maxHealth;
                        sleeping = false;
                    }
                    else if (player1.health + 5 > player1.maxHealth)
                    {
                        //calculation to regenerate less than 5hp if playerHp+5 is over player hp cap
                        float hpRegen = player1.maxHealth - player1.health;
                        player1.health += hpRegen;
                        Console.WriteLine($"You've regenerated {hpRegen} health, you now have {player1.health} health");
                    }
                    else
                    {
                        player1.health += 5;
                        Console.WriteLine($"You've regenerated 5 health, you now have {player1.health} health");
                    }
                }
                #endregion
            }


            //battle function
            void BattleFunction()
            {
                #region battle choices
                battleChoice = false;
                while (battleChoice == false)
                {
                    Console.Clear();
                    Console.WriteLine("1:rats\n2:wolfs\n3:bears\n4:back to main menu");
                    try
                    {
                        battle = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Unexpected error occurred, please try again");

                    }
                    #endregion //battle choices
                    #region battle switch
                    switch (battle)
                    {

                        case 1:
                            #region rat battle case
                            #region rat battle info
                            Console.Clear();
                            ratLevel1.PrintOutInfo();
                            ratLevel2.PrintOutInfo();
                            eliteRat.PrintOutInfo();
                            bossRat.PrintOutInfo();
                            Console.WriteLine("1:rat level 1\n2:rat level 2\n3:elite rat\n4:Rat King\n5: exit to main menu");

                            ratBattle = int.Parse(Console.ReadLine());
                            #endregion //rat battle info

                            switch (ratBattle)
                            {
                                #region rat battles
                                #region rat level 1 battle
                                case 1:

                                    isBattleActive = true;
                                    while (isBattleActive)
                                    {

                                        Console.Clear();
                                        Console.WriteLine("what do you want to do:\n1:attack\n2:block\n3:run");
                                        string battleActionChoice = Console.ReadLine();



                                        switch (battleActionChoice)
                                        {
                                            case "1":
                                                #region player hit calculation
                                                Console.Clear();
                                                playerDmg = dmgRnd.Next(Convert.ToInt32(player1.minDmg), Convert.ToInt32(player1.maxDmg));
                                                defenseFormula = defenseFormulaRandomize.Next(0, Convert.ToInt32(ratLevel1.defense));
                                                playerDmg = playerDmg - defenseFormula;
                                                if (playerDmg - defenseFormula < 0)
                                                {
                                                    playerDmg = 0;
                                                }
                                                ratLevel1.health -= playerDmg;
                                                Console.WriteLine($"You dealt {playerDmg} damage");
                                                Console.WriteLine($"{ratLevel1.name} have {ratLevel1.health}/{ratLevel1.maxHealth} health left\npress enter to continue");
                                                Console.ReadLine();



                                                #endregion player hit calculation



                                                #region enemy hit calculation
                                                ratLevel1.damage = dmgRnd.Next(1, ratLevel1.damage);
                                                defenseFormula = defenseFormulaRandomize.Next(0, Convert.ToInt32(player1.defense));
                                                if (ratLevel1.damage - defenseFormula < 0)
                                                {
                                                    ratLevel1.damage = 0;
                                                    defenseFormula = 0;
                                                }
                                                if (ratLevel1.health > 0)
                                                {
                                                    player1.health -= ratLevel1.damage - defenseFormula;
                                                    Console.WriteLine($"Rat level 1 dealt {ratLevel1.damage - defenseFormula} damage");
                                                    Console.WriteLine($"you have {player1.health}/{player1.maxHealth} health left\npress enter to continue");
                                                    Console.ReadLine();

                                                    ratLevel1.damage = 2;
                                                }
                                                #endregion enemy hit calculation
                                                break;
                                            case "2":
                                                Console.Clear();
                                                player1.defense += 10;
                                                Console.WriteLine($"blocking temporarily increased your defense by 10\nyour defense:{player1.defense}");
                                                Console.ReadLine();
                                                #region enemy hit calculation
                                                ratLevel1.damage = dmgRnd.Next(1, ratLevel1.damage);
                                                defenseFormula = defenseFormulaRandomize.Next(0, Convert.ToInt32(player1.defense));
                                                if (ratLevel1.damage - defenseFormula < 0)
                                                {
                                                    ratLevel1.damage = 0;
                                                    defenseFormula = 0;
                                                }
                                                if (ratLevel1.health > 0)
                                                {
                                                    player1.health -= ratLevel1.damage - defenseFormula;
                                                    Console.WriteLine($"Rat level 1 dealt {ratLevel1.damage - defenseFormula} damage");
                                                    Console.WriteLine($"you have {player1.health}/{player1.maxHealth} health left\npress enter to continue");
                                                    Console.ReadLine();
                                                    ratLevel1.damage = 2;
                                                    player1.defense -= 10;

                                                }
                                                #endregion enemy hit calculation

                                                break;
                                            case "3":
                                                bool run = true;
                                                int runChance = 0;
                                                if (run == true)
                                                {
                                                    Console.Clear();
                                                    runChance = runChanceRandom.Next(Convert.ToInt32(playerMinDex), Convert.ToInt32(player1.dex));
                                                    if (runChance >= 40)
                                                    {
                                                        Console.WriteLine("You have successfully ran out of the battle");
                                                        Console.WriteLine("Be more careful when going into tough battles next time");
                                                        Console.ReadLine();
                                                        isBattleActive = false;

                                                    }
                                                    else if (runChance < 40)
                                                    {
                                                        Console.WriteLine("You've failed to run from this battle, better luck next time");
                                                        #region enemy hit calculation
                                                        ratLevel1.damage = dmgRnd.Next(1, ratLevel1.damage);
                                                        defenseFormula = defenseFormulaRandomize.Next(0, Convert.ToInt32(player1.defense));
                                                        if (ratLevel1.damage - defenseFormula < 0)
                                                        {
                                                            ratLevel1.damage = 0;
                                                            defenseFormula = 0;
                                                        }
                                                        if (ratLevel1.health > 0)
                                                        {
                                                            player1.health -= ratLevel1.damage - defenseFormula;
                                                            Console.WriteLine($"Rat level 1 dealt {ratLevel1.damage - defenseFormula} damage");
                                                            Console.WriteLine($"you have {player1.health}/{player1.maxHealth} health left\npress enter to continue");
                                                            Console.ReadLine();
                                                            ratLevel1.damage = 2;


                                                        }
                                                        #endregion enemy hit calculation
                                                    }
                                                }

                                                break;
                                            default:
                                                Console.WriteLine("error, action not found");
                                                Thread.Sleep(500);
                                                Console.Clear();
                                                battleChoice = true;

                                                break;
                                        }
                                        if (ratLevel1.health <= 0)
                                        {
                                            xpGain = 10;
                                            coinGain = 5;
                                            player1.exp += xpGain;
                                            player1.coins += coinGain;

                                            Console.Clear();
                                            Console.WriteLine("Rat level 1 died, Congratulations!");
                                            Console.WriteLine($"You've gained {xpGain} exp and {coinGain} Kricoins\nYou now have {player1.exp} exp and {player1.coins} Kricoins\npress enter to continue");
                                            Console.ReadLine();
                                            isBattleActive = false;
                                            ratLevel1.health = 15;
                                            ratLevel1.damage = 2;
                                            ratLevel1.defense = 0;

                                        }
                                        if (player1.health <= 0)
                                        {
                                            isBattleActive = false;
                                            death = true;
                                            battleChoice = true;
                                        }

                                    }

                                    break;
                                #endregion
                                #region Rat Level 2 Battle
                                case 2:

                                    isBattleActive = true;
                                    while (isBattleActive)
                                    {

                                        Console.Clear();
                                        Console.WriteLine("what do you want to do:\n1:attack\n2:block");
                                        try
                                        {
                                            battleActionChoice = int.Parse(Console.ReadLine());
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("Unspecified error occurred, please try again");

                                        }

                                        switch (battleActionChoice)
                                        {
                                            case 1:

                                                #region player hit calculation
                                                Console.Clear();
                                                playerDmg = dmgRnd.Next(Convert.ToInt32(player1.minDmg), Convert.ToInt32(player1.maxDmg));
                                                defenseFormula = defenseFormulaRandomize.Next(0, Convert.ToInt32(ratLevel2.defense));
                                                playerDmg = playerDmg - defenseFormula;
                                                if (playerDmg - defenseFormula < 0)
                                                {
                                                    playerDmg = 0;
                                                }
                                                ratLevel2.health -= playerDmg;
                                                Console.WriteLine($"You dealt {playerDmg} damage");
                                                Console.WriteLine($"{ratLevel2.name} have {ratLevel2.health}/{ratLevel2.maxHealth} health left\npress enter to continue");
                                                Console.ReadLine();




                                                #endregion player hit calculation

                                                //
                                                //enemy hit calculation
                                                ratLevel2.damage = dmgRnd.Next(2, ratLevel2.damage);
                                                defenseFormula = defenseFormulaRandomize.Next(0, Convert.ToInt32(player1.defense));
                                                if (ratLevel2.damage - defenseFormula < 0)
                                                {
                                                    ratLevel2.damage = 0;
                                                    defenseFormula = 0;
                                                }
                                                if (ratLevel2.health > 0.5)
                                                {
                                                    player1.health -= ratLevel2.damage - defenseFormula;
                                                    Console.WriteLine($"Rat level 2 dealt {ratLevel2.damage - defenseFormula} damage");
                                                    Console.WriteLine($"you have {player1.health}/{player1.maxHealth} health left\npress enter to continue");
                                                    Console.ReadLine();
                                                    // playerDmg = player1.damage;
                                                    ratLevel2.damage = 3;
                                                }

                                                break;
                                            case 2:
                                                Console.Clear();
                                                player1.defense += 10;
                                                Console.WriteLine($"blocking temporarily increased your defense by 10\nyour defense:{player1.defense}");
                                                Console.ReadLine();
                                                //enemy hit calculation
                                                ratLevel2.damage = dmgRnd.Next(2, ratLevel2.damage);
                                                defenseFormula = defenseFormulaRandomize.Next(0, Convert.ToInt32(player1.defense));
                                                if (ratLevel2.damage - defenseFormula < 0)
                                                {
                                                    ratLevel2.damage = 0;
                                                    defenseFormula = 0;
                                                }
                                                if (ratLevel2.health > 1)
                                                {
                                                    player1.health -= ratLevel2.damage - defenseFormula;
                                                    Console.WriteLine($"Rat level 2 dealt {ratLevel2.damage - defenseFormula} damage");
                                                    Console.WriteLine($"you have {player1.health}/{player1.maxHealth} health left\npress enter to continue");
                                                    Console.ReadLine();
                                                    ratLevel2.damage = 3;
                                                    player1.defense -= 10;

                                                }


                                                break;
                                            default:
                                                Console.WriteLine("error, action not found");
                                                Thread.Sleep(500);
                                                Console.Clear();
                                                battleChoice = true;

                                                break;
                                        }
                                        if (ratLevel2.health <= 0)
                                        {

                                            xpGain = 20;
                                            coinGain = 10;
                                            player1.exp += xpGain;
                                            player1.coins += coinGain;



                                            Console.Clear();
                                            Console.WriteLine("Rat level 2 died, Congratulations!");
                                            Console.WriteLine($"You've gained {xpGain} exp and {coinGain} Kricoins\nYou now have {player1.exp} exp and {player1.coins} Kricoins\npress enter to continue");
                                            Console.ReadLine();
                                            isBattleActive = false;
                                            ratLevel2.health = 25;
                                            ratLevel2.damage = 3;
                                            ratLevel2.defense = 1;

                                        }
                                        if (player1.health <= 0)
                                        {
                                            isBattleActive = false;
                                            death = true;
                                            battleChoice = true;
                                        }

                                    }
                                    break;
                                #endregion
                                #region elite rat Battle
                                case 3:

                                    isBattleActive = true;
                                    while (isBattleActive)
                                    {

                                        Console.Clear();
                                        Console.WriteLine("what do you want to do:\n1:attack\n2:block");
                                        try
                                        {
                                            battleActionChoice = int.Parse(Console.ReadLine());
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("Unspecified error occurred, please try again");

                                        }

                                        switch (battleActionChoice)
                                        {
                                            case 1:
                                                #region player hit calculation
                                                Console.Clear();
                                                playerDmg = dmgRnd.Next(Convert.ToInt32(player1.minDmg), Convert.ToInt32(player1.maxDmg));
                                                defenseFormula = defenseFormulaRandomize.Next(0, Convert.ToInt32(eliteRat.defense));
                                                playerDmg = playerDmg - defenseFormula;
                                                if (playerDmg - defenseFormula < 0)
                                                {
                                                    playerDmg = 0;
                                                }
                                                eliteRat.health -= playerDmg;
                                                Console.WriteLine($"You dealt {playerDmg} damage");
                                                Console.WriteLine($"{eliteRat.name} have {eliteRat.health}/{eliteRat.maxHealth} health left\npress enter to continue");
                                                Console.ReadLine();

                                                #endregion player hit calculation

                                                //enemy hit calculation
                                                eliteRat.damage = dmgRnd.Next(3, eliteRat.damage);
                                                defenseFormula = defenseFormulaRandomize.Next(0, Convert.ToInt32(player1.defense));
                                                if (eliteRat.damage - defenseFormula < 0)
                                                {
                                                    eliteRat.damage = 0;
                                                    defenseFormula = 0;
                                                }
                                                if (eliteRat.health > 0.5)
                                                {
                                                    player1.health -= eliteRat.damage - defenseFormula;
                                                    Console.WriteLine($"Elite rat dealt {eliteRat.damage - defenseFormula} damage");
                                                    Console.WriteLine($"you have {player1.health}/{player1.maxHealth} health left\npress enter to continue");
                                                    Console.ReadLine();
                                                    // playerDmg = player1.damage;
                                                    eliteRat.damage = 5;
                                                }

                                                break;
                                            case 2:
                                                Console.Clear();
                                                player1.defense += 10;
                                                Console.WriteLine($"blocking temporarily increased your defense by 10\nyour defense:{player1.defense}");
                                                Console.ReadLine();
                                                //enemy hit calculation
                                                eliteRat.damage = dmgRnd.Next(3, eliteRat.damage);
                                                defenseFormula = defenseFormulaRandomize.Next(0, Convert.ToInt32(player1.defense));
                                                if (eliteRat.damage - defenseFormula < 0)
                                                {
                                                    eliteRat.damage = 0;
                                                    defenseFormula = 0;
                                                }
                                                if (eliteRat.health > 1)
                                                {
                                                    player1.health -= eliteRat.damage - defenseFormula;
                                                    Console.WriteLine($"Elite rat dealt {eliteRat.damage - defenseFormula} damage");
                                                    Console.WriteLine($"you have {player1.health}/{player1.maxHealth} health left\npress enter to continue");
                                                    Console.ReadLine();
                                                    eliteRat.damage = 5;
                                                    player1.defense -= 10;

                                                }


                                                break;
                                            default:
                                                Console.WriteLine("error, action not found");
                                                Thread.Sleep(500);
                                                Console.Clear();
                                                battleChoice = true;

                                                break;
                                        }
                                        if (eliteRat.health <= 0)
                                        {

                                            xpGain = 40;
                                            coinGain = 30;
                                            player1.exp += xpGain;
                                            player1.coins += coinGain;



                                            Console.Clear();
                                            Console.WriteLine("Elite rat died, Congratulations!");
                                            Console.WriteLine($"You've gained {xpGain} exp and {coinGain} Kricoins\nYou now have {player1.exp} exp and {player1.coins} Kricoins\npress enter to continue");
                                            Console.ReadLine();
                                            isBattleActive = false;
                                            eliteRat.health = 50;
                                            eliteRat.damage = 5;
                                            eliteRat.defense = 2;

                                        }
                                        if (player1.health <= 0)
                                        {
                                            isBattleActive = false;
                                            death = true;
                                            battleChoice = true;
                                        }

                                    }
                                    break;
                                #endregion
                                #region boss rat Battle
                                case 4:

                                    isBattleActive = true;
                                    while (isBattleActive)
                                    {

                                        Console.Clear();
                                        Console.WriteLine("what do you want to do:\n1:attack\n2:block");
                                        try
                                        {
                                            battleActionChoice = int.Parse(Console.ReadLine());
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("Unspecified error occurred, please try again");

                                        }

                                        switch (battleActionChoice)
                                        {
                                            case 1:
                                                #region player hit calculation
                                                Console.Clear();
                                                playerDmg = dmgRnd.Next(Convert.ToInt32(player1.minDmg), Convert.ToInt32(player1.maxDmg));
                                                defenseFormula = defenseFormulaRandomize.Next(0, Convert.ToInt32(bossRat.defense));
                                                playerDmg = playerDmg - defenseFormula;
                                                if (playerDmg - defenseFormula < 0)
                                                {
                                                    playerDmg = 0;
                                                }
                                                bossRat.health -= playerDmg;
                                                Console.WriteLine($"You dealt {playerDmg} damage");
                                                Console.WriteLine($"{bossRat.name} have {bossRat.health}/{bossRat.maxHealth} health left\npress enter to continue");
                                                Console.ReadLine();

                                                #endregion player hit calculation
                                                //enemy hit calculation
                                                bossRat.damage = dmgRnd.Next(5, bossRat.damage);
                                                defenseFormula = defenseFormulaRandomize.Next(0, Convert.ToInt32(player1.defense));
                                                if (bossRat.damage - defenseFormula < 0)
                                                {
                                                    bossRat.damage = 0;
                                                    defenseFormula = 0;
                                                }
                                                if (bossRat.health > 0.5)
                                                {
                                                    player1.health -= bossRat.damage - defenseFormula;
                                                    Console.WriteLine($"rat king dealt {bossRat.damage - defenseFormula} damage");
                                                    Console.WriteLine($"you have {player1.health}/{player1.maxHealth} health left\npress enter to continue");
                                                    Console.ReadLine();
                                                    // playerDmg = player1.damage;
                                                    bossRat.damage = 10;
                                                }

                                                break;
                                            case 2:
                                                Console.Clear();
                                                player1.defense += 10;
                                                Console.WriteLine($"blocking temporarily increased your defense by 10\nyour defense:{player1.defense}");
                                                Console.ReadLine();
                                                //enemy hit calculation
                                                bossRat.damage = dmgRnd.Next(5, bossRat.damage);
                                                defenseFormula = defenseFormulaRandomize.Next(0, Convert.ToInt32(player1.defense));
                                                if (bossRat.damage - defenseFormula < 0)
                                                {
                                                    bossRat.damage = 0;
                                                    defenseFormula = 0;
                                                }
                                                if (bossRat.health > 1)
                                                {
                                                    player1.health -= bossRat.damage - defenseFormula;
                                                    Console.WriteLine($"rat king dealt {bossRat.damage - defenseFormula} damage");
                                                    Console.WriteLine($"you have {player1.health}/{player1.maxHealth} health left\npress enter to continue");
                                                    Console.ReadLine();
                                                    bossRat.damage = 10;
                                                    player1.defense -= 10;

                                                }


                                                break;
                                            default:
                                                Console.WriteLine("error, action not found");
                                                Thread.Sleep(500);
                                                Console.Clear();
                                                battleChoice = true;

                                                break;
                                        }
                                        if (bossRat.health <= 0)
                                        {

                                            xpGain = 100;
                                            coinGain = 80;
                                            player1.exp += xpGain;
                                            player1.coins += coinGain;



                                            Console.Clear();
                                            Console.WriteLine("rat king died, Congratulations!");
                                            Console.WriteLine($"You've gained {xpGain} exp and {coinGain} Kricoins\nYou now have {player1.exp} exp and {player1.coins} Kricoins\npress enter to continue");
                                            Console.ReadLine();
                                            isBattleActive = false;
                                            bossRat.health = 100;
                                            bossRat.damage = 10;
                                            bossRat.defense = 5;

                                        }
                                        if (player1.health <= 0)
                                        {
                                            isBattleActive = false;
                                            death = true;
                                            battleChoice = true;
                                        }

                                    }
                                    #endregion boss rat Battle
                                    break;
                                case 5:
                                    Console.Clear();
                                    battleChoice = true;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("error enemy type not found");
                                    battleChoice = true;
                                    break;

                                    #endregion //rat battles
                            }
                            #endregion //rat battle case
                            break;
                        case 2:
                            #region wolf battle case
                            #endregion //wolf battle case
                            break;

                        case 4:
                            //back to main menu function
                            battleChoice = true;
                            Console.Clear();
                            break;
                        //
                        default:
                            Console.Clear();
                            Console.WriteLine("Error enemy not found");
                            Thread.Sleep(1500);
                            break;
                    }
                }

                #endregion //battle switch
            }
            //shop function
            void Shop()
            {
                #region Shop main menu
                shopActive = true;
                while (shopActive)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome To the shop! What do you want to do?\n1)Buy Helmets\n2)Buy Chestplates\n3)Buy Gloves\n4)Buy Leggings\n5)Buy Boots\n6)Exit Shop");
                    #endregion Shop main menu
                    #region Shop main menu choices
                    shopMainMenuChoices = Console.ReadLine();
                    switch (shopMainMenuChoices)
                    {

                        case "1":

                            HelmetShop();

                            break;
                        case "2":

                            ChestplateShop();

                            break;
                        case "3":

                            GlovesShop();

                            break;
                        case "6":
                            shopActive = false;
                            Console.Clear();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine($"Error choice {shopMainMenuChoices} does not exist, press enter to continue");
                            Console.ReadLine();
                            break;

                    }

                }
                #endregion Shop main menu Choices

            }

            #region Helmet shop Functions
            void HelmetShop()
            {
                #region Helmet shop main menu
                Console.Clear();
                Console.WriteLine("Welcome to helmet shop\nWhat do you want to do?\n1)buy Helmets\n2)Show helmet prices\n3)back to shop");
                string helmetShopChoices = Console.ReadLine();
                switch (helmetShopChoices)
                {
                    case "1":
                        HelmetBuyMenu();
                        break;
                    case "2":
                        HelmetPriceMenu();
                        break;
                    default:
                        Console.WriteLine($"error choice {helmetShopChoices} was not found, please try again");
                        break;
                }
                #endregion Helmet shop main menu
            }

            void HelmetPriceMenu()
            {
                #region helmet price info menu
                string helmetPriceMenuPage = "1";

                bool helmetPriceMenu = true;
                while (helmetPriceMenu)
                {
                    Console.Clear();

                    switch (helmetPriceMenuPage)
                    {

                        case "1":

                            #region helmet price info page 1
                            Console.Clear();
                            leatherHelmet.PrintOutPrice();
                            copperHelmet.PrintOutPrice();
                            bronzeHelmet.PrintOutPrice();
                            ironHelmet.PrintOutPrice();
                            steelHelmet.PrintOutPrice();
                            dwarvenHelmet.PrintOutPrice();
                            orcishHelmet.PrintOutPrice();
                            steelOrcishHelmet.PrintOutPrice();
                            ebonyHelmet.PrintOutPrice();
                            Console.WriteLine("2)go to page 2\n3)back to helmet shop");
                            helmetPriceMenuPage = Console.ReadLine();
                            #endregion helmet price info page 1
                            break;
                        case "2":

                            #region helmet price info page 2
                            Console.Clear();
                            dragonBoneHelmet.PrintOutPrice();
                            teathriumHelmet.PrintOutPrice();
                            dragonplateHelmet.PrintOutPrice();
                            ancientTeathriumHelmet.PrintOutPrice();
                            demotriumDragonHelmet.PrintOutPrice();
                            Console.WriteLine($"\n1)go to page 1\n3)back to helmet shop");
                            helmetPriceMenuPage = Console.ReadLine();
                            #endregion helmet price info page 2
                            break;
                        case "3":
                            helmetPriceMenu = false;
                            break;
                        default:
                            Console.WriteLine($"error page {helmetPriceMenuPage} not found");
                            helmetPriceMenu = false;
                            Console.ReadLine();
                            break;
                    }





                }
                #endregion helmet price info menu
            }

            void HelmetBuyMenu()
            {
                #region Helmet shop buy
                bool helmetBuyMenu = false;
                while (helmetBuyMenu == false)
                {
                    #region Buy Menu
                    Console.Clear();
                    Console.WriteLine("What Helmet you want to buy?:");
                    Console.WriteLine($"1){leatherHelmet.name}\n2){copperHelmet.name}\n3){bronzeHelmet.name}\n4){ironHelmet.name}\n5){steelHelmet.name}");
                    Console.WriteLine($"6){dwarvenHelmet.name}\n7){orcishHelmet.name}\n8){steelOrcishHelmet.name}\n9){ebonyHelmet.name}\n10){dragonBoneHelmet.name}");
                    Console.WriteLine($"11){teathriumHelmet.name}\n12){dragonplateHelmet.name}\n13){ancientTeathriumHelmet.name}\n14){demotriumDragonHelmet.name}\n\n15)Back to Shop");
                    string helmetBuyChoice = Console.ReadLine();
                    #endregion Buy Menu
                    switch (helmetBuyChoice)
                    {
                        #region all Helmets
                        case "1":
                            #region Leather Helmet
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Helmet price is {leatherHelmet.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {leatherHelmet.name} ?");
                            Console.WriteLine($"1)yes\n2)no, back to Shop");
                            string buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= leatherHelmet.price && leatherHelmet.equiped == false)
                                    {
                                        player1.coins -= leatherHelmet.price;
                                        leatherHelmet.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Helmet bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        helmetBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < leatherHelmet.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {leatherHelmet.name} price is {leatherHelmet.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this helmet
                                    else if (leatherHelmet.equiped)
                                    {
                                        Console.WriteLine("error, you already own this helmet");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this helmet
                                    #region Calculation
                                    if (leatherHelmet.equiped)
                                    {
                                        helmetEquipment.hp = 0;
                                        helmetEquipment.dmg = 0;
                                        helmetEquipment.def = 0;
                                        helmetEquipment.hp = leatherHelmet.health;
                                        helmetEquipment.dmg = leatherHelmet.damage;
                                        helmetEquipment.def = leatherHelmet.defense;
                                        helmetEquipment.name = leatherHelmet.name;
                                        equipmentStats = false;
                                        #region other helmets unequip
                                        /*leatherHelmet.equiped = false;*/
                                        copperHelmet.equiped = false;
                                        bronzeHelmet.equiped = false;
                                        ironHelmet.equiped = false;
                                        steelHelmet.equiped = false;
                                        dwarvenHelmet.equiped = false;
                                        orcishHelmet.equiped = false;
                                        steelOrcishHelmet.equiped = false;
                                        ebonyHelmet.equiped = false;
                                        dragonBoneHelmet.equiped = false;
                                        teathriumHelmet.equiped = false;
                                        dragonplateHelmet.equiped = false;
                                        ancientTeathriumHelmet.equiped = false;
                                        demotriumDragonHelmet.equiped = false;
                                        #endregion other helmets unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    helmetBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Leather Helmet
                            break;

                        case "2":
                            #region Copper Helmet
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Helmet price is {copperHelmet.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {copperHelmet.name} ?");
                            Console.WriteLine($"1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= copperHelmet.price && copperHelmet.equiped == false)
                                    {
                                        player1.coins -= copperHelmet.price;
                                        copperHelmet.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Helmet bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        helmetBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < copperHelmet.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {copperHelmet.name} price is {copperHelmet.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this helmet
                                    else if (copperHelmet.equiped)
                                    {
                                        Console.WriteLine("error, you already own this helmet");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this helmet
                                    #region Calculation
                                    if (copperHelmet.equiped)
                                    {
                                        helmetEquipment.hp = 0;
                                        helmetEquipment.dmg = 0;
                                        helmetEquipment.def = 0;
                                        helmetEquipment.hp = copperHelmet.health;
                                        helmetEquipment.dmg = copperHelmet.damage;
                                        helmetEquipment.def = copperHelmet.defense;
                                        helmetEquipment.name = copperHelmet.name;
                                        equipmentStats = false;
                                        #region other helmets unequip
                                        leatherHelmet.equiped = false;
                                        /*copperHelmet.equiped = false;*/
                                        bronzeHelmet.equiped = false;
                                        ironHelmet.equiped = false;
                                        steelHelmet.equiped = false;
                                        dwarvenHelmet.equiped = false;
                                        orcishHelmet.equiped = false;
                                        steelOrcishHelmet.equiped = false;
                                        ebonyHelmet.equiped = false;
                                        dragonBoneHelmet.equiped = false;
                                        teathriumHelmet.equiped = false;
                                        dragonplateHelmet.equiped = false;
                                        ancientTeathriumHelmet.equiped = false;
                                        demotriumDragonHelmet.equiped = false;
                                        #endregion other helmets unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    helmetBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Copper Helmet
                            break;

                        case "3":
                            #region Bronze Helmet
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Helmet price is {bronzeHelmet.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {bronzeHelmet.name} ?");
                            Console.WriteLine($"1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= bronzeHelmet.price && bronzeHelmet.equiped == false)
                                    {
                                        player1.coins -= bronzeHelmet.price;
                                        bronzeHelmet.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Helmet bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        helmetBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < bronzeHelmet.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {bronzeHelmet.name} price is {bronzeHelmet.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this helmet
                                    else if (bronzeHelmet.equiped)
                                    {
                                        Console.WriteLine("error, you already own this helmet");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this helmet
                                    #region Calculation
                                    if (bronzeHelmet.equiped)
                                    {
                                        helmetEquipment.hp = 0;
                                        helmetEquipment.dmg = 0;
                                        helmetEquipment.def = 0;
                                        helmetEquipment.hp = bronzeHelmet.health;
                                        helmetEquipment.dmg = bronzeHelmet.damage;
                                        helmetEquipment.def = bronzeHelmet.defense;
                                        helmetEquipment.name = bronzeHelmet.name;
                                        equipmentStats = false;
                                        #region other helmets unequip
                                        leatherHelmet.equiped = false;
                                        copperHelmet.equiped = false;
                                        /* bronzeHelmet.equiped = false;*/
                                        ironHelmet.equiped = false;
                                        steelHelmet.equiped = false;
                                        dwarvenHelmet.equiped = false;
                                        orcishHelmet.equiped = false;
                                        steelOrcishHelmet.equiped = false;
                                        ebonyHelmet.equiped = false;
                                        dragonBoneHelmet.equiped = false;
                                        teathriumHelmet.equiped = false;
                                        dragonplateHelmet.equiped = false;
                                        ancientTeathriumHelmet.equiped = false;
                                        demotriumDragonHelmet.equiped = false;
                                        #endregion other helmets unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    helmetBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Bronze Helmet
                            break;

                        case "4":
                            #region Iron Helmet
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Helmet price is {ironHelmet.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {ironHelmet.name} ?");
                            Console.WriteLine($"1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= ironHelmet.price && ironHelmet.equiped == false)
                                    {
                                        player1.coins -= ironHelmet.price;
                                        ironHelmet.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Helmet bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        helmetBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < ironHelmet.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {ironHelmet.name} price is {ironHelmet.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this helmet
                                    else if (ironHelmet.equiped)
                                    {
                                        Console.WriteLine("error, you already own this helmet");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this helmet
                                    #region Calculation
                                    if (ironHelmet.equiped)
                                    {
                                        helmetEquipment.hp = 0;
                                        helmetEquipment.dmg = 0;
                                        helmetEquipment.def = 0;
                                        helmetEquipment.hp = ironHelmet.health;
                                        helmetEquipment.dmg = ironHelmet.damage;
                                        helmetEquipment.def = ironHelmet.defense;
                                        helmetEquipment.name = ironHelmet.name;
                                        equipmentStats = false;
                                        #region other helmets unequip
                                        leatherHelmet.equiped = false;
                                        copperHelmet.equiped = false;
                                        bronzeHelmet.equiped = false;
                                        /*ironHelmet.equiped = false;*/
                                        steelHelmet.equiped = false;
                                        dwarvenHelmet.equiped = false;
                                        orcishHelmet.equiped = false;
                                        steelOrcishHelmet.equiped = false;
                                        ebonyHelmet.equiped = false;
                                        dragonBoneHelmet.equiped = false;
                                        teathriumHelmet.equiped = false;
                                        dragonplateHelmet.equiped = false;
                                        ancientTeathriumHelmet.equiped = false;
                                        demotriumDragonHelmet.equiped = false;
                                        #endregion other helmets unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    helmetBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Iron Helmet
                            break;

                        case "5":
                            #region Steel Helmet
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Helmet price is {steelHelmet.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {steelHelmet.name} ?");
                            Console.WriteLine($"1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= steelHelmet.price && steelHelmet.equiped == false)
                                    {
                                        player1.coins -= steelHelmet.price;
                                        steelHelmet.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Helmet bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        helmetBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < steelHelmet.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {steelHelmet.name} price is {steelHelmet.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this helmet
                                    else if (steelHelmet.equiped)
                                    {
                                        Console.WriteLine("error, you already own this helmet");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this helmet
                                    #region Calculation
                                    if (steelHelmet.equiped)
                                    {
                                        helmetEquipment.hp = 0;
                                        helmetEquipment.dmg = 0;
                                        helmetEquipment.def = 0;
                                        helmetEquipment.hp = steelHelmet.health;
                                        helmetEquipment.dmg = steelHelmet.damage;
                                        helmetEquipment.def = steelHelmet.defense;
                                        helmetEquipment.name = steelHelmet.name;
                                        equipmentStats = false;
                                        #region other helmets unequip
                                        leatherHelmet.equiped = false;
                                        copperHelmet.equiped = false;
                                        bronzeHelmet.equiped = false;
                                        ironHelmet.equiped = false;
                                        /*steelHelmet.equiped = false;*/
                                        dwarvenHelmet.equiped = false;
                                        orcishHelmet.equiped = false;
                                        steelOrcishHelmet.equiped = false;
                                        ebonyHelmet.equiped = false;
                                        dragonBoneHelmet.equiped = false;
                                        teathriumHelmet.equiped = false;
                                        dragonplateHelmet.equiped = false;
                                        ancientTeathriumHelmet.equiped = false;
                                        demotriumDragonHelmet.equiped = false;
                                        #endregion other helmets unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    helmetBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Steel Helmet
                            break;

                        case "6":
                            #region Dwarven Helmet
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Helmet price is {dwarvenHelmet.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {dwarvenHelmet.name} ?");
                            Console.WriteLine($"1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= dwarvenHelmet.price && dwarvenHelmet.equiped == false)
                                    {
                                        player1.coins -= dwarvenHelmet.price;
                                        dwarvenHelmet.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Helmet bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        helmetBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < dwarvenHelmet.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {dwarvenHelmet.name} price is {dwarvenHelmet.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this helmet
                                    else if (dwarvenHelmet.equiped)
                                    {
                                        Console.WriteLine("error, you already own this helmet");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this helmet
                                    #region Calculation
                                    if (dwarvenHelmet.equiped)
                                    {
                                        helmetEquipment.hp = 0;
                                        helmetEquipment.dmg = 0;
                                        helmetEquipment.def = 0;
                                        helmetEquipment.hp = dwarvenHelmet.health;
                                        helmetEquipment.dmg = dwarvenHelmet.damage;
                                        helmetEquipment.def = dwarvenHelmet.defense;
                                        helmetEquipment.name = dwarvenHelmet.name;
                                        equipmentStats = false;
                                        #region other helmets unequip
                                        leatherHelmet.equiped = false;
                                        copperHelmet.equiped = false;
                                        bronzeHelmet.equiped = false;
                                        ironHelmet.equiped = false;
                                        steelHelmet.equiped = false;
                                        /*dwarvenHelmet.equiped = false;*/
                                        orcishHelmet.equiped = false;
                                        steelOrcishHelmet.equiped = false;
                                        ebonyHelmet.equiped = false;
                                        dragonBoneHelmet.equiped = false;
                                        teathriumHelmet.equiped = false;
                                        dragonplateHelmet.equiped = false;
                                        ancientTeathriumHelmet.equiped = false;
                                        demotriumDragonHelmet.equiped = false;
                                        #endregion other helmets unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    helmetBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Dwarven Helmet
                            break;

                        case "7":
                            #region Orcish Helmet
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Helmet price is {orcishHelmet.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {orcishHelmet.name} ?");
                            Console.WriteLine($"1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= orcishHelmet.price && orcishHelmet.equiped == false)
                                    {
                                        player1.coins -= orcishHelmet.price;
                                        orcishHelmet.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Helmet bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        helmetBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < orcishHelmet.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {orcishHelmet.name} price is {orcishHelmet.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this helmet
                                    else if (orcishHelmet.equiped)
                                    {
                                        Console.WriteLine("error, you already own this helmet");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this helmet
                                    #region Calculation
                                    if (orcishHelmet.equiped)
                                    {
                                        helmetEquipment.hp = 0;
                                        helmetEquipment.dmg = 0;
                                        helmetEquipment.def = 0;
                                        helmetEquipment.hp = orcishHelmet.health;
                                        helmetEquipment.dmg = orcishHelmet.damage;
                                        helmetEquipment.def = orcishHelmet.defense;
                                        helmetEquipment.name = orcishHelmet.name;
                                        equipmentStats = false;
                                        #region other helmets unequip
                                        leatherHelmet.equiped = false;
                                        copperHelmet.equiped = false;
                                        bronzeHelmet.equiped = false;
                                        ironHelmet.equiped = false;
                                        steelHelmet.equiped = false;
                                        dwarvenHelmet.equiped = false;
                                        /*orcishHelmet.equiped = false;*/
                                        steelOrcishHelmet.equiped = false;
                                        ebonyHelmet.equiped = false;
                                        dragonBoneHelmet.equiped = false;
                                        teathriumHelmet.equiped = false;
                                        dragonplateHelmet.equiped = false;
                                        ancientTeathriumHelmet.equiped = false;
                                        demotriumDragonHelmet.equiped = false;
                                        #endregion other helmets unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    helmetBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Orcish Helmet
                            break;

                        case "8":
                            #region Steel orcish Helmet
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Helmet price is {steelOrcishHelmet.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {steelOrcishHelmet.name} ?");
                            Console.WriteLine($"1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= steelOrcishHelmet.price && steelOrcishHelmet.equiped == false)
                                    {
                                        player1.coins -= steelOrcishHelmet.price;
                                        steelOrcishHelmet.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Helmet bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        helmetBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < steelOrcishHelmet.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {steelOrcishHelmet.name} price is {steelOrcishHelmet.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this helmet
                                    else if (steelOrcishHelmet.equiped)
                                    {
                                        Console.WriteLine("error, you already own this helmet");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this helmet
                                    #region Calculation
                                    if (steelOrcishHelmet.equiped)
                                    {
                                        helmetEquipment.hp = 0;
                                        helmetEquipment.dmg = 0;
                                        helmetEquipment.def = 0;
                                        helmetEquipment.hp = steelOrcishHelmet.health;
                                        helmetEquipment.dmg = steelOrcishHelmet.damage;
                                        helmetEquipment.def = steelOrcishHelmet.defense;
                                        helmetEquipment.name = steelOrcishHelmet.name;
                                        equipmentStats = false;
                                        #region other helmets unequip
                                        leatherHelmet.equiped = false;
                                        copperHelmet.equiped = false;
                                        bronzeHelmet.equiped = false;
                                        ironHelmet.equiped = false;
                                        steelHelmet.equiped = false;
                                        dwarvenHelmet.equiped = false;
                                        orcishHelmet.equiped = false;
                                        /* steelOrcishHelmet.equiped = false;*/
                                        ebonyHelmet.equiped = false;
                                        dragonBoneHelmet.equiped = false;
                                        teathriumHelmet.equiped = false;
                                        dragonplateHelmet.equiped = false;
                                        ancientTeathriumHelmet.equiped = false;
                                        demotriumDragonHelmet.equiped = false;
                                        #endregion other helmets unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    helmetBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Steel orcish Helmet
                            break;

                        case "9":
                            #region Ebony Helmet
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Helmet price is {ebonyHelmet.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {ebonyHelmet.name} ?");
                            Console.WriteLine($"1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= ebonyHelmet.price && ebonyHelmet.equiped == false)
                                    {
                                        player1.coins -= ebonyHelmet.price;
                                        ebonyHelmet.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Helmet bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        helmetBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < ebonyHelmet.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {ebonyHelmet.name} price is {ebonyHelmet.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this helmet
                                    else if (ebonyHelmet.equiped)
                                    {
                                        Console.WriteLine("error, you already own this helmet");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this helmet
                                    #region Calculation
                                    if (ebonyHelmet.equiped)
                                    {
                                        helmetEquipment.hp = 0;
                                        helmetEquipment.dmg = 0;
                                        helmetEquipment.def = 0;
                                        helmetEquipment.hp = ebonyHelmet.health;
                                        helmetEquipment.dmg = ebonyHelmet.damage;
                                        helmetEquipment.def = ebonyHelmet.defense;
                                        helmetEquipment.name = ebonyHelmet.name;
                                        equipmentStats = false;
                                        #region other helmets unequip
                                        leatherHelmet.equiped = false;
                                        copperHelmet.equiped = false;
                                        bronzeHelmet.equiped = false;
                                        ironHelmet.equiped = false;
                                        steelHelmet.equiped = false;
                                        dwarvenHelmet.equiped = false;
                                        orcishHelmet.equiped = false;
                                        steelOrcishHelmet.equiped = false;
                                        /*ebonyHelmet.equiped = false;*/
                                        dragonBoneHelmet.equiped = false;
                                        teathriumHelmet.equiped = false;
                                        dragonplateHelmet.equiped = false;
                                        ancientTeathriumHelmet.equiped = false;
                                        demotriumDragonHelmet.equiped = false;
                                        #endregion other helmets unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    helmetBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Ebony Helmet
                            break;

                        case "10":
                            #region Dragon Bone Helmet
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Helmet price is {dragonBoneHelmet.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {dragonBoneHelmet.name} ?");
                            Console.WriteLine($"1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= dragonBoneHelmet.price && dragonBoneHelmet.equiped == false)
                                    {
                                        player1.coins -= dragonBoneHelmet.price;
                                        dragonBoneHelmet.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Helmet bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        helmetBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < dragonBoneHelmet.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {dragonBoneHelmet.name} price is {dragonBoneHelmet.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this helmet
                                    else if (dragonBoneHelmet.equiped)
                                    {
                                        Console.WriteLine("error, you already own this helmet");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this helmet
                                    #region Calculation
                                    if (dragonBoneHelmet.equiped)
                                    {
                                        helmetEquipment.hp = 0;
                                        helmetEquipment.dmg = 0;
                                        helmetEquipment.def = 0;
                                        helmetEquipment.hp = dragonBoneHelmet.health;
                                        helmetEquipment.dmg = dragonBoneHelmet.damage;
                                        helmetEquipment.def = dragonBoneHelmet.defense;
                                        helmetEquipment.name = dragonBoneHelmet.name;
                                        equipmentStats = false;
                                        #region other helmets unequip
                                        leatherHelmet.equiped = false;
                                        copperHelmet.equiped = false;
                                        bronzeHelmet.equiped = false;
                                        ironHelmet.equiped = false;
                                        steelHelmet.equiped = false;
                                        dwarvenHelmet.equiped = false;
                                        orcishHelmet.equiped = false;
                                        steelOrcishHelmet.equiped = false;
                                        ebonyHelmet.equiped = false;
                                        /* dragonBoneHelmet.equiped = false;*/
                                        teathriumHelmet.equiped = false;
                                        dragonplateHelmet.equiped = false;
                                        ancientTeathriumHelmet.equiped = false;
                                        demotriumDragonHelmet.equiped = false;
                                        #endregion other helmets unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    helmetBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Ebony Helmet
                            break;

                        case "11":
                            #region Teathrium Helmet
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Helmet price is {teathriumHelmet.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {teathriumHelmet.name} ?");
                            Console.WriteLine($"1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= teathriumHelmet.price && teathriumHelmet.equiped == false)
                                    {
                                        player1.coins -= teathriumHelmet.price;
                                        teathriumHelmet.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Helmet bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        helmetBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < teathriumHelmet.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {teathriumHelmet.name} price is {teathriumHelmet.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this helmet
                                    else if (teathriumHelmet.equiped)
                                    {
                                        Console.WriteLine("error, you already own this helmet");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this helmet
                                    #region Calculation
                                    if (teathriumHelmet.equiped)
                                    {
                                        helmetEquipment.hp = 0;
                                        helmetEquipment.dmg = 0;
                                        helmetEquipment.def = 0;
                                        helmetEquipment.hp = teathriumHelmet.health;
                                        helmetEquipment.dmg = teathriumHelmet.damage;
                                        helmetEquipment.def = teathriumHelmet.defense;
                                        helmetEquipment.name = teathriumHelmet.name;
                                        equipmentStats = false;
                                        #region other helmets unequip
                                        leatherHelmet.equiped = false;
                                        copperHelmet.equiped = false;
                                        bronzeHelmet.equiped = false;
                                        ironHelmet.equiped = false;
                                        steelHelmet.equiped = false;
                                        dwarvenHelmet.equiped = false;
                                        orcishHelmet.equiped = false;
                                        steelOrcishHelmet.equiped = false;
                                        ebonyHelmet.equiped = false;
                                        dragonBoneHelmet.equiped = false;
                                        /* teathriumHelmet.equiped = false;*/
                                        dragonplateHelmet.equiped = false;
                                        ancientTeathriumHelmet.equiped = false;
                                        demotriumDragonHelmet.equiped = false;
                                        #endregion other helmets unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    helmetBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Teathrium Helmet
                            break;

                        case "12":
                            #region Dragon Plate Helmet
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Helmet price is {dragonplateHelmet.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {dragonplateHelmet.name} ?");
                            Console.WriteLine($"1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= dragonplateHelmet.price && dragonplateHelmet.equiped == false)
                                    {
                                        player1.coins -= dragonplateHelmet.price;
                                        dragonplateHelmet.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Helmet bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        helmetBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < dragonplateHelmet.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {dragonplateHelmet.name} price is {dragonplateHelmet.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this helmet
                                    else if (dragonplateHelmet.equiped)
                                    {
                                        Console.WriteLine("error, you already own this helmet");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this helmet
                                    #region Calculation
                                    if (dragonplateHelmet.equiped)
                                    {
                                        helmetEquipment.hp = 0;
                                        helmetEquipment.dmg = 0;
                                        helmetEquipment.def = 0;
                                        helmetEquipment.hp = dragonplateHelmet.health;
                                        helmetEquipment.dmg = dragonplateHelmet.damage;
                                        helmetEquipment.def = dragonplateHelmet.defense;
                                        helmetEquipment.name = dragonplateHelmet.name;
                                        equipmentStats = false;
                                        #region other helmets unequip
                                        leatherHelmet.equiped = false;
                                        copperHelmet.equiped = false;
                                        bronzeHelmet.equiped = false;
                                        ironHelmet.equiped = false;
                                        steelHelmet.equiped = false;
                                        dwarvenHelmet.equiped = false;
                                        orcishHelmet.equiped = false;
                                        steelOrcishHelmet.equiped = false;
                                        ebonyHelmet.equiped = false;
                                        dragonBoneHelmet.equiped = false;
                                        teathriumHelmet.equiped = false;
                                        /* dragonplateHelmet.equiped = false;*/
                                        ancientTeathriumHelmet.equiped = false;
                                        demotriumDragonHelmet.equiped = false;
                                        #endregion other helmets unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    helmetBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Dragon Plate Helmet
                            break;

                        case "13":
                            #region Ancient Teathrium Helmet
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Helmet price is {ancientTeathriumHelmet.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {ancientTeathriumHelmet.name} ?");
                            Console.WriteLine($"1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= ancientTeathriumHelmet.price && ancientTeathriumHelmet.equiped == false)
                                    {
                                        player1.coins -= ancientTeathriumHelmet.price;
                                        ancientTeathriumHelmet.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Helmet bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        helmetBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < ancientTeathriumHelmet.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {ancientTeathriumHelmet.name} price is {ancientTeathriumHelmet.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this helmet
                                    else if (ancientTeathriumHelmet.equiped)
                                    {
                                        Console.WriteLine("error, you already own this helmet");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this helmet
                                    #region Calculation
                                    if (ancientTeathriumHelmet.equiped)
                                    {
                                        helmetEquipment.hp = 0;
                                        helmetEquipment.dmg = 0;
                                        helmetEquipment.def = 0;
                                        helmetEquipment.hp = ancientTeathriumHelmet.health;
                                        helmetEquipment.dmg = ancientTeathriumHelmet.damage;
                                        helmetEquipment.def = ancientTeathriumHelmet.defense;
                                        helmetEquipment.name = ancientTeathriumHelmet.name;
                                        equipmentStats = false;
                                        #region other helmets unequip
                                        leatherHelmet.equiped = false;
                                        copperHelmet.equiped = false;
                                        bronzeHelmet.equiped = false;
                                        ironHelmet.equiped = false;
                                        steelHelmet.equiped = false;
                                        dwarvenHelmet.equiped = false;
                                        orcishHelmet.equiped = false;
                                        steelOrcishHelmet.equiped = false;
                                        ebonyHelmet.equiped = false;
                                        dragonBoneHelmet.equiped = false;
                                        teathriumHelmet.equiped = false;
                                        dragonplateHelmet.equiped = false;
                                        /* ancientTeathriumHelmet.equiped = false;*/
                                        demotriumDragonHelmet.equiped = false;
                                        #endregion other helmets unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    helmetBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Ancient teathrium Helmet
                            break;

                        case "14":
                            #region Demotrium Dragon Helmet
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Helmet price is {demotriumDragonHelmet.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {demotriumDragonHelmet.name} ?");
                            Console.WriteLine($"1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= demotriumDragonHelmet.price && demotriumDragonHelmet.equiped == false)
                                    {
                                        player1.coins -= demotriumDragonHelmet.price;
                                        demotriumDragonHelmet.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Helmet bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        helmetBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < demotriumDragonHelmet.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {demotriumDragonHelmet.name} price is {demotriumDragonHelmet.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this helmet
                                    else if (demotriumDragonHelmet.equiped)
                                    {
                                        Console.WriteLine("error, you already own this helmet");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this helmet
                                    #region Calculation
                                    if (demotriumDragonHelmet.equiped)
                                    {
                                        helmetEquipment.hp = 0;
                                        helmetEquipment.dmg = 0;
                                        helmetEquipment.def = 0;
                                        helmetEquipment.hp = demotriumDragonHelmet.health;
                                        helmetEquipment.dmg = demotriumDragonHelmet.damage;
                                        helmetEquipment.def = demotriumDragonHelmet.defense;
                                        helmetEquipment.name = demotriumDragonHelmet.name;
                                        equipmentStats = false;
                                        #region other helmets unequip
                                        leatherHelmet.equiped = false;
                                        copperHelmet.equiped = false;
                                        bronzeHelmet.equiped = false;
                                        ironHelmet.equiped = false;
                                        steelHelmet.equiped = false;
                                        dwarvenHelmet.equiped = false;
                                        orcishHelmet.equiped = false;
                                        steelOrcishHelmet.equiped = false;
                                        ebonyHelmet.equiped = false;
                                        dragonBoneHelmet.equiped = false;
                                        teathriumHelmet.equiped = false;
                                        dragonplateHelmet.equiped = false;
                                        ancientTeathriumHelmet.equiped = false;
                                        /*  demotriumDragonHelmet.equiped = false;*/
                                        #endregion other helmets unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    helmetBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Demotrium Dragon Helmet
                            break;

                        #endregion all Helmets

                        case "15":
                            helmetBuyMenu = true;

                            break;
                        default:
                            Console.WriteLine($"helmet {helmetBuyChoice} does not exist, try again");
                            break;
                    }

                }

                #endregion Helmet shop buy
            }
            #endregion Helmet shop Functions

            #region Chestplate shop Functions
            void ChestplateShop()
            {
                #region Chestplate shop main menu
                Console.Clear();
                Console.WriteLine("Welcome to chestplate shop\nWhat do you want to do?\n1)buy Chestplates\n2)Show Chestplate prices\n3)back to shop");
                string chestplateShopChoices = Console.ReadLine();
                switch (chestplateShopChoices)
                {
                    case "1":
                        ChestplateBuyMenu();
                        break;
                    case "2":
                        ChestplatePriceMenu();
                        break;
                    default:
                        Console.WriteLine($"error choice {chestplateShopChoices} was not found, please try again");
                        break;
                }
                #endregion Chestplate shop main menu
            }

            void ChestplatePriceMenu()
            {
                #region chestplate price info menu
                string chestplatePriceMenuPage = "1";

                bool chestplatePriceMenu = true;
                while (chestplatePriceMenu)
                {
                    Console.Clear();

                    switch (chestplatePriceMenuPage)
                    {

                        case "1":

                            #region Chestplate price info page 1
                            Console.Clear();
                            leatherChestplate.PrintOutPrice();
                            copperChestplate.PrintOutPrice();
                            bronzeChestplate.PrintOutPrice();
                            ironChestplate.PrintOutPrice();
                            steelChestplate.PrintOutPrice();
                            dwarvenChestplate.PrintOutPrice();
                            orcishChestplate.PrintOutPrice();
                            steelOrcishChestplate.PrintOutPrice();
                            ebonyChestplate.PrintOutPrice();
                            Console.WriteLine($"2)go to page 2\n3)back to chestplate shop");
                            chestplatePriceMenuPage = Console.ReadLine();
                            #endregion chestplate price info page 1
                            break;
                        case "2":

                            #region Chestplate price info page 2
                            Console.Clear();
                            dragonBoneChestplate.PrintOutPrice();
                            teathriumChestplate.PrintOutPrice();
                            dragonplateChestplate.PrintOutPrice();
                            ancientTeathriumChestplate.PrintOutPrice();
                            demotriumDragonChestplate.PrintOutPrice();
                            Console.WriteLine($"\n1)go to page 1\n3)back to chestplate shop");
                            chestplatePriceMenuPage = Console.ReadLine();
                            #endregion chestplate price info page 2
                            break;
                        case "3":
                            chestplatePriceMenu = false;
                            break;
                        default:
                            Console.WriteLine($"error page {chestplatePriceMenuPage} not found");
                            chestplatePriceMenu = false;
                            Console.ReadLine();
                            break;
                    }





                }
                #endregion chestplate price info menu
            }

            void ChestplateBuyMenu()
            {
                #region Chestplate shop buy
                bool chestplateBuyMenu = false;
                while (chestplateBuyMenu == false)
                {
                    #region Buy Menu
                    Console.Clear();
                    Console.WriteLine("What Chestplate you want to buy?:");
                    Console.WriteLine($"1){leatherChestplate.name}\n2){copperChestplate.name}\n3){bronzeChestplate.name}\n4){ironChestplate.name}\n5){steelChestplate.name}");
                    Console.WriteLine($"6){dwarvenChestplate.name}\n7){orcishChestplate.name}\n8){steelOrcishChestplate.name}\n9){ebonyChestplate.name}\n10){dragonBoneChestplate.name}");
                    Console.WriteLine($"11){teathriumChestplate.name}\n12){dragonplateChestplate.name}\n13){ancientTeathriumChestplate.name}\n14){demotriumDragonChestplate.name}\n\n15)Back to Shop");
                    string chestplateBuyChoice = Console.ReadLine();
                    #endregion Buy Menu
                    switch (chestplateBuyChoice)
                    {
                        #region all Chestplates
                        case "1":
                            #region Leather Chestplate
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Chestplate price is {leatherChestplate.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {leatherChestplate.name} ?");
                            Console.WriteLine($"1)yes\n2)no, back to Shop");
                            string buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= leatherChestplate.price && leatherChestplate.equiped == false)
                                    {
                                        player1.coins -= leatherChestplate.price;
                                        leatherChestplate.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Chestplate bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        chestplateBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < leatherChestplate.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {leatherChestplate.name} price is {leatherChestplate.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this Chestplate
                                    else if (leatherChestplate.equiped)
                                    {
                                        Console.WriteLine("error, you already own this chestplate");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this Chestplate
                                    #region Calculation
                                    if (leatherChestplate.equiped)
                                    {
                                        chestplateEquipment.hp = 0;
                                        chestplateEquipment.dmg = 0;
                                        chestplateEquipment.def = 0;
                                        chestplateEquipment.hp = leatherChestplate.health;
                                        chestplateEquipment.dmg = leatherChestplate.damage;
                                        chestplateEquipment.def = leatherChestplate.defense;
                                        equipmentStats = false;
                                        #region other Chestplate unequip
                                        /*leatherChestplate.equiped = false;*/
                                        copperChestplate.equiped = false;
                                        bronzeChestplate.equiped = false;
                                        ironChestplate.equiped = false;
                                        steelChestplate.equiped = false;
                                        dwarvenChestplate.equiped = false;
                                        orcishChestplate.equiped = false;
                                        steelOrcishChestplate.equiped = false;
                                        ebonyChestplate.equiped = false;
                                        dragonBoneChestplate.equiped = false;
                                        teathriumChestplate.equiped = false;
                                        dragonplateChestplate.equiped = false;
                                        ancientTeathriumChestplate.equiped = false;
                                        demotriumDragonChestplate.equiped = false;
                                        #endregion other Chestplate unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    chestplateBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Leather Chestplate
                            break;

                        case "2":
                            #region Copper Chestplate
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Chestplate price is {copperChestplate.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {copperChestplate.name} ?");
                            Console.WriteLine($"1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= copperChestplate.price && copperChestplate.equiped == false)
                                    {
                                        player1.coins -= copperChestplate.price;
                                        copperChestplate.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Chestplate bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        chestplateBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < copperChestplate.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {copperChestplate.name} price is {copperChestplate.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this Chestplate
                                    else if (copperChestplate.equiped)
                                    {
                                        Console.WriteLine("error, you already own this chestplate");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this helmet
                                    #region Calculation
                                    if (copperChestplate.equiped)
                                    {
                                        chestplateEquipment.hp = 0;
                                        chestplateEquipment.dmg = 0;
                                        chestplateEquipment.def = 0;
                                        chestplateEquipment.hp = copperChestplate.health;
                                        chestplateEquipment.dmg = copperChestplate.damage;
                                        chestplateEquipment.def = copperChestplate.defense;
                                        equipmentStats = false;
                                        #region other Chestplate unequip
                                        leatherChestplate.equiped = false;
                                        /*copperChestplate.equiped = false;*/
                                        bronzeChestplate.equiped = false;
                                        ironChestplate.equiped = false;
                                        steelChestplate.equiped = false;
                                        dwarvenChestplate.equiped = false;
                                        orcishChestplate.equiped = false;
                                        steelOrcishChestplate.equiped = false;
                                        ebonyChestplate.equiped = false;
                                        dragonBoneChestplate.equiped = false;
                                        teathriumChestplate.equiped = false;
                                        dragonplateChestplate.equiped = false;
                                        ancientTeathriumChestplate.equiped = false;
                                        demotriumDragonChestplate.equiped = false;
                                        #endregion other Chestplate unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    chestplateBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Copper Chestplate
                            break;

                        case "3":
                            #region Bronze Chestplate
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Chestplate price is {bronzeChestplate.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {bronzeChestplate.name} ?");
                            Console.WriteLine($"1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= bronzeChestplate.price && bronzeChestplate.equiped == false)
                                    {
                                        player1.coins -= bronzeChestplate.price;
                                        bronzeChestplate.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Chestplate bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        chestplateBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < bronzeChestplate.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {bronzeChestplate.name} price is {bronzeChestplate.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this Chestplate
                                    else if (bronzeChestplate.equiped)
                                    {
                                        Console.WriteLine("error, you already own this chestplate");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this Chestplate
                                    #region Calculation
                                    if (bronzeChestplate.equiped)
                                    {
                                        chestplateEquipment.hp = 0;
                                        chestplateEquipment.dmg = 0;
                                        chestplateEquipment.def = 0;
                                        chestplateEquipment.hp = bronzeChestplate.health;
                                        chestplateEquipment.dmg = bronzeChestplate.damage;
                                        chestplateEquipment.def = bronzeChestplate.defense;
                                        equipmentStats = false;
                                        #region other Chestplate unequip
                                        leatherChestplate.equiped = false;
                                        copperChestplate.equiped = false;
                                        /* bronzeChestplate.equiped = false;*/
                                        ironChestplate.equiped = false;
                                        steelChestplate.equiped = false;
                                        dwarvenChestplate.equiped = false;
                                        orcishChestplate.equiped = false;
                                        steelOrcishChestplate.equiped = false;
                                        ebonyChestplate.equiped = false;
                                        dragonBoneChestplate.equiped = false;
                                        teathriumChestplate.equiped = false;
                                        dragonplateChestplate.equiped = false;
                                        ancientTeathriumChestplate.equiped = false;
                                        demotriumDragonChestplate.equiped = false;
                                        #endregion other Chestplate unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    chestplateBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Bronze Chestplate
                            break;

                        case "4":
                            #region Iron Chestplate
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Chestplate price is {ironChestplate.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {ironChestplate.name} ?");
                            Console.WriteLine($"1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= ironChestplate.price && ironChestplate.equiped == false)
                                    {
                                        player1.coins -= ironChestplate.price;
                                        ironChestplate.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Chestplate bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        chestplateBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < ironChestplate.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {ironChestplate.name} price is {ironChestplate.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this Chestplate
                                    else if (ironChestplate.equiped)
                                    {
                                        Console.WriteLine("error, you already own this chestplate");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this Chestplate
                                    #region Calculation
                                    if (ironChestplate.equiped)
                                    {
                                        chestplateEquipment.hp = 0;
                                        chestplateEquipment.dmg = 0;
                                        chestplateEquipment.def = 0;
                                        chestplateEquipment.hp = ironChestplate.health;
                                        chestplateEquipment.dmg = ironChestplate.damage;
                                        chestplateEquipment.def = ironChestplate.defense;
                                        equipmentStats = false;
                                        #region other Chestplate unequip
                                        leatherChestplate.equiped = false;
                                        copperChestplate.equiped = false;
                                        bronzeChestplate.equiped = false;
                                        /*ironChestplate.equiped = false;*/
                                        steelChestplate.equiped = false;
                                        dwarvenChestplate.equiped = false;
                                        orcishChestplate.equiped = false;
                                        steelOrcishChestplate.equiped = false;
                                        ebonyChestplate.equiped = false;
                                        dragonBoneChestplate.equiped = false;
                                        teathriumChestplate.equiped = false;
                                        dragonplateChestplate.equiped = false;
                                        ancientTeathriumChestplate.equiped = false;
                                        demotriumDragonChestplate.equiped = false;
                                        #endregion other Chestplate unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    chestplateBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Iron Chestplate
                            break;

                        case "5":
                            #region Steel Chestplate
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Chestplate price is {steelChestplate.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {steelChestplate.name} ?");
                            Console.WriteLine($"1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= steelChestplate.price && steelChestplate.equiped == false)
                                    {
                                        player1.coins -= steelChestplate.price;
                                        steelChestplate.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Chestplate bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        chestplateBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < steelChestplate.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {steelChestplate.name} price is {steelChestplate.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this Chestplate
                                    else if (steelChestplate.equiped)
                                    {
                                        Console.WriteLine("error, you already own this chestplate");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this helmet
                                    #region Calculation
                                    if (steelChestplate.equiped)
                                    {
                                        chestplateEquipment.hp = 0;
                                        chestplateEquipment.dmg = 0;
                                        chestplateEquipment.def = 0;
                                        chestplateEquipment.hp = ironChestplate.health;
                                        chestplateEquipment.dmg = ironChestplate.damage;
                                        chestplateEquipment.def = ironChestplate.defense;
                                        equipmentStats = false;
                                        #region other Chestplate unequip
                                        leatherChestplate.equiped = false;
                                        copperChestplate.equiped = false;
                                        bronzeChestplate.equiped = false;
                                        ironChestplate.equiped = false;
                                        /*steelChestplate.equiped = false;*/
                                        dwarvenChestplate.equiped = false;
                                        orcishChestplate.equiped = false;
                                        steelOrcishChestplate.equiped = false;
                                        ebonyChestplate.equiped = false;
                                        dragonBoneChestplate.equiped = false;
                                        teathriumChestplate.equiped = false;
                                        dragonplateChestplate.equiped = false;
                                        ancientTeathriumChestplate.equiped = false;
                                        demotriumDragonChestplate.equiped = false;
                                        #endregion other Chestplate unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    chestplateBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Steel Chestplate
                            break;

                        case "6":
                            #region Dwarven Chestplate
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Chestplate price is {dwarvenChestplate.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {dwarvenChestplate.name} ?");
                            Console.WriteLine($"1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= dwarvenChestplate.price && dwarvenChestplate.equiped == false)
                                    {
                                        player1.coins -= dwarvenChestplate.price;
                                        dwarvenChestplate.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Chestplate bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        chestplateBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < dwarvenChestplate.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {dwarvenChestplate.name} price is {dwarvenChestplate.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this Chestplate
                                    else if (dwarvenChestplate.equiped)
                                    {
                                        Console.WriteLine("error, you already own this chestplate");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this Chestplate
                                    #region Calculation
                                    if (dwarvenChestplate.equiped)
                                    {
                                        chestplateEquipment.hp = 0;
                                        chestplateEquipment.dmg = 0;
                                        chestplateEquipment.def = 0;
                                        chestplateEquipment.hp = dwarvenChestplate.health;
                                        chestplateEquipment.dmg = dwarvenChestplate.damage;
                                        chestplateEquipment.def = dwarvenChestplate.defense;
                                        equipmentStats = false;
                                        #region other Chestplate unequip
                                        leatherChestplate.equiped = false;
                                        copperChestplate.equiped = false;
                                        bronzeChestplate.equiped = false;
                                        ironChestplate.equiped = false;
                                        steelChestplate.equiped = false;
                                        /*dwarvenChestplate .equiped = false;*/
                                        orcishChestplate.equiped = false;
                                        steelOrcishChestplate.equiped = false;
                                        ebonyChestplate.equiped = false;
                                        dragonBoneChestplate.equiped = false;
                                        teathriumChestplate.equiped = false;
                                        dragonplateChestplate.equiped = false;
                                        ancientTeathriumChestplate.equiped = false;
                                        demotriumDragonChestplate.equiped = false;
                                        #endregion other Chestplate unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    chestplateBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Dwarven Chestplate
                            break;

                        case "7":
                            #region Orcish Chestplate
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Chestplate  price is {orcishChestplate.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {orcishChestplate.name} ?");
                            Console.WriteLine($"1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= orcishChestplate.price && orcishChestplate.equiped == false)
                                    {
                                        player1.coins -= orcishChestplate.price;
                                        orcishChestplate.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Chestplate  bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        chestplateBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < orcishChestplate.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {orcishChestplate.name} price is {orcishChestplate.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this helmet
                                    else if (orcishChestplate.equiped)
                                    {
                                        Console.WriteLine("error, you already own this chestplate");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this helmet
                                    #region Calculation
                                    if (orcishChestplate.equiped)
                                    {
                                        chestplateEquipment.hp = 0;
                                        chestplateEquipment.dmg = 0;
                                        chestplateEquipment.def = 0;
                                        chestplateEquipment.hp = orcishChestplate.health;
                                        chestplateEquipment.dmg = orcishChestplate.damage;
                                        chestplateEquipment.def = orcishChestplate.defense;
                                        equipmentStats = false;
                                        #region other chestplate unequip
                                        leatherChestplate.equiped = false;
                                        copperChestplate.equiped = false;
                                        bronzeChestplate.equiped = false;
                                        ironChestplate.equiped = false;
                                        steelChestplate.equiped = false;
                                        dwarvenChestplate.equiped = false;
                                        /*orcishChestplate.equiped = false;*/
                                        steelOrcishChestplate.equiped = false;
                                        ebonyChestplate.equiped = false;
                                        dragonBoneChestplate.equiped = false;
                                        teathriumChestplate.equiped = false;
                                        dragonplateChestplate.equiped = false;
                                        ancientTeathriumChestplate.equiped = false;
                                        demotriumDragonChestplate.equiped = false;
                                        #endregion other Chestplate unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    chestplateBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Orcish Chestplate
                            break;

                        case "8":
                            #region Steel orcish Chestplate
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Chestplate price is {steelOrcishChestplate.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {steelOrcishChestplate.name} ?");
                            Console.WriteLine($"1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= steelOrcishChestplate.price && steelOrcishChestplate.equiped == false)
                                    {
                                        player1.coins -= steelOrcishChestplate.price;
                                        steelOrcishChestplate.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Chestplate bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        chestplateBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < steelOrcishChestplate.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {steelOrcishChestplate.name} price is {steelOrcishChestplate.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this Chestplate
                                    else if (steelOrcishChestplate.equiped)
                                    {
                                        Console.WriteLine("error, you already own this chestplate");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this Chestplate
                                    #region Calculation
                                    if (steelOrcishChestplate.equiped)
                                    {
                                        chestplateEquipment.hp = 0;
                                        chestplateEquipment.dmg = 0;
                                        chestplateEquipment.def = 0;
                                        chestplateEquipment.hp = steelOrcishChestplate.health;
                                        chestplateEquipment.dmg = steelOrcishChestplate.damage;
                                        chestplateEquipment.def = steelOrcishChestplate.defense;
                                        equipmentStats = false;
                                        #region other Chestplate unequip
                                        leatherChestplate.equiped = false;
                                        copperChestplate.equiped = false;
                                        bronzeChestplate.equiped = false;
                                        ironChestplate.equiped = false;
                                        steelChestplate.equiped = false;
                                        dwarvenChestplate.equiped = false;
                                        orcishChestplate.equiped = false;
                                        /* steelOrcishChestplate.equiped = false;*/
                                        ebonyChestplate.equiped = false;
                                        dragonBoneChestplate.equiped = false;
                                        teathriumChestplate.equiped = false;
                                        dragonplateChestplate.equiped = false;
                                        ancientTeathriumChestplate.equiped = false;
                                        demotriumDragonChestplate.equiped = false;
                                        #endregion other Chestplate unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    chestplateBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Steel orcish Chestplate
                            break;

                        case "9":
                            #region ebony Chestplate
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Chestplate price is {ebonyChestplate.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {ebonyChestplate.name} ?");
                            Console.WriteLine($"1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= ebonyChestplate.price && ebonyChestplate.equiped == false)
                                    {
                                        player1.coins -= ebonyChestplate.price;
                                        ebonyChestplate.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Chestplate bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        chestplateBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < ebonyHelmet.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {ebonyHelmet.name} price is {ebonyHelmet.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this Chestplate
                                    else if (ebonyChestplate.equiped)
                                    {
                                        Console.WriteLine("error, you already own this chestplate");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this Chestplate
                                    #region Calculation
                                    if (ebonyChestplate.equiped)
                                    {
                                        chestplateEquipment.hp = 0;
                                        chestplateEquipment.dmg = 0;
                                        chestplateEquipment.def = 0;
                                        chestplateEquipment.hp = ebonyChestplate.health;
                                        chestplateEquipment.dmg = ebonyChestplate.damage;
                                        chestplateEquipment.def = ebonyChestplate.defense;
                                        equipmentStats = false;
                                        #region other Chestplate unequip
                                        leatherChestplate.equiped = false;
                                        copperChestplate.equiped = false;
                                        bronzeChestplate.equiped = false;
                                        ironChestplate.equiped = false;
                                        steelChestplate.equiped = false;
                                        dwarvenChestplate.equiped = false;
                                        orcishChestplate.equiped = false;
                                        steelOrcishChestplate.equiped = false;
                                        /*ebonyChestplate.equiped = false;*/
                                        dragonBoneChestplate.equiped = false;
                                        teathriumChestplate.equiped = false;
                                        dragonplateChestplate.equiped = false;
                                        ancientTeathriumChestplate.equiped = false;
                                        demotriumDragonChestplate.equiped = false;
                                        #endregion other helmets unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    chestplateBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Ebony Chestplate
                            break;

                        case "10":
                            #region Dragon Bone Chestplate
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Chestplate price is {dragonBoneChestplate.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {dragonBoneChestplate.name} ?");
                            Console.WriteLine("1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= dragonBoneChestplate.price && dragonBoneChestplate.equiped == false)
                                    {
                                        player1.coins -= dragonBoneChestplate.price;
                                        dragonBoneChestplate.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Chestplate bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        chestplateBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < dragonBoneChestplate.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {dragonBoneChestplate.name} price is {dragonBoneChestplate.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this Chestplate
                                    else if (dragonBoneChestplate.equiped)
                                    {
                                        Console.WriteLine("error, you already own this chestplate");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this Chestplate
                                    #region Calculation
                                    if (dragonBoneChestplate.equiped)
                                    {
                                        chestplateEquipment.hp = 0;
                                        chestplateEquipment.dmg = 0;
                                        chestplateEquipment.def = 0;
                                        chestplateEquipment.hp = dragonBoneChestplate.health;
                                        chestplateEquipment.dmg = dragonBoneChestplate.damage;
                                        chestplateEquipment.def = dragonBoneChestplate.defense;
                                        equipmentStats = false;
                                        #region other Chestplate unequip
                                        leatherChestplate.equiped = false;
                                        copperChestplate.equiped = false;
                                        bronzeChestplate.equiped = false;
                                        ironChestplate.equiped = false;
                                        steelChestplate.equiped = false;
                                        dwarvenChestplate.equiped = false;
                                        orcishChestplate.equiped = false;
                                        steelOrcishChestplate.equiped = false;
                                        ebonyChestplate.equiped = false;
                                        /* dragonBoneChestplate.equiped = false;*/
                                        teathriumChestplate.equiped = false;
                                        dragonplateChestplate.equiped = false;
                                        ancientTeathriumChestplate.equiped = false;
                                        demotriumDragonChestplate.equiped = false;
                                        #endregion other Chestplate unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    chestplateBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Dragon Bone Chestplate
                            break;

                        case "11":
                            #region Teathrium Chestplate
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Chestplate price is {teathriumChestplate.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {teathriumChestplate.name} ?");
                            Console.WriteLine($"1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= teathriumChestplate.price && teathriumChestplate.equiped == false)
                                    {
                                        player1.coins -= teathriumChestplate.price;
                                        teathriumChestplate.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Chestplate bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        chestplateBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < teathriumChestplate.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {teathriumChestplate.name} price is {teathriumChestplate.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this chestplate
                                    else if (teathriumChestplate.equiped)
                                    {
                                        Console.WriteLine("error, you already own this chestplate");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this chestplate
                                    #region Calculation
                                    if (teathriumChestplate.equiped)
                                    {
                                        chestplateEquipment.hp = 0;
                                        chestplateEquipment.dmg = 0;
                                        chestplateEquipment.def = 0;
                                        chestplateEquipment.hp = teathriumChestplate.health;
                                        chestplateEquipment.dmg = teathriumChestplate.damage;
                                        chestplateEquipment.def = teathriumChestplate.defense;
                                        equipmentStats = false;
                                        #region other  chestplate unequip
                                        leatherChestplate.equiped = false;
                                        copperChestplate.equiped = false;
                                        bronzeChestplate.equiped = false;
                                        ironChestplate.equiped = false;
                                        steelChestplate.equiped = false;
                                        dwarvenChestplate.equiped = false;
                                        orcishChestplate.equiped = false;
                                        steelOrcishChestplate.equiped = false;
                                        ebonyChestplate.equiped = false;
                                        dragonBoneChestplate.equiped = false;
                                        /* teathriumChestplate.equiped = false;*/
                                        dragonplateChestplate.equiped = false;
                                        ancientTeathriumChestplate.equiped = false;
                                        demotriumDragonChestplate.equiped = false;
                                        #endregion other chestplate unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    chestplateBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Teathrium Chestplate
                            break;

                        case "12":
                            #region Dragon Plate Chestplate
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Chestplate price is {dragonplateChestplate.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {dragonplateChestplate.name} ?");
                            Console.WriteLine("1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= dragonplateChestplate.price && dragonplateChestplate.equiped == false)
                                    {
                                        player1.coins -= dragonplateChestplate.price;
                                        dragonplateChestplate.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Chestplate bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        chestplateBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < dragonplateChestplate.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {dragonplateChestplate.name} price is {dragonplateChestplate.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this Chestplate
                                    else if (dragonplateChestplate.equiped)
                                    {
                                        Console.WriteLine("error, you already own this chestplate");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this Chestplate
                                    #region Calculation
                                    if (dragonplateChestplate.equiped)
                                    {
                                        chestplateEquipment.hp = 0;
                                        chestplateEquipment.dmg = 0;
                                        chestplateEquipment.def = 0;
                                        chestplateEquipment.hp = dragonplateChestplate.health;
                                        chestplateEquipment.dmg = dragonplateChestplate.damage;
                                        chestplateEquipment.def = dragonplateChestplate.defense;
                                        equipmentStats = false;
                                        #region other Chestplate unequip
                                        leatherChestplate.equiped = false;
                                        copperChestplate.equiped = false;
                                        bronzeChestplate.equiped = false;
                                        ironChestplate.equiped = false;
                                        steelChestplate.equiped = false;
                                        dwarvenChestplate.equiped = false;
                                        orcishChestplate.equiped = false;
                                        steelOrcishChestplate.equiped = false;
                                        ebonyChestplate.equiped = false;
                                        dragonBoneChestplate.equiped = false;
                                        teathriumChestplate.equiped = false;
                                        /* dragonplateChestplate.equiped = false;*/
                                        ancientTeathriumChestplate.equiped = false;
                                        demotriumDragonChestplate.equiped = false;
                                        #endregion other Chestplate unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    chestplateBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Dragon Plate Chestplate
                            break;

                        case "13":
                            #region Ancient Teathrium Chestplate
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Chestplate price is {ancientTeathriumChestplate.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {ancientTeathriumChestplate.name} ?");
                            Console.WriteLine("1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= ancientTeathriumChestplate.price && ancientTeathriumChestplate.equiped == false)
                                    {
                                        player1.coins -= ancientTeathriumChestplate.price;
                                        ancientTeathriumChestplate.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Chestplate bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        chestplateBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < ancientTeathriumChestplate.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {ancientTeathriumChestplate.name} price is {ancientTeathriumChestplate.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this Chestplate
                                    else if (ancientTeathriumChestplate.equiped)
                                    {
                                        Console.WriteLine("error, you already own this chestplate");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this Chestplate
                                    #region Calculation
                                    if (ancientTeathriumChestplate.equiped)
                                    {
                                        chestplateEquipment.hp = 0;
                                        chestplateEquipment.dmg = 0;
                                        chestplateEquipment.def = 0;
                                        chestplateEquipment.hp = ancientTeathriumChestplate.health;
                                        chestplateEquipment.dmg = ancientTeathriumChestplate.damage;
                                        chestplateEquipment.def = ancientTeathriumChestplate.defense;
                                        equipmentStats = false;
                                        #region other chestplate unequip
                                        leatherChestplate.equiped = false;
                                        copperChestplate.equiped = false;
                                        bronzeChestplate.equiped = false;
                                        ironChestplate.equiped = false;
                                        steelChestplate.equiped = false;
                                        dwarvenChestplate.equiped = false;
                                        orcishChestplate.equiped = false;
                                        steelOrcishChestplate.equiped = false;
                                        ebonyChestplate.equiped = false;
                                        dragonBoneChestplate.equiped = false;
                                        teathriumChestplate.equiped = false;
                                        dragonplateChestplate.equiped = false;
                                        /* ancientTeathriumChestplate.equiped = false;*/
                                        demotriumDragonChestplate.equiped = false;
                                        #endregion other chestplate unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    chestplateBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Ancient teathrium Helmet
                            break;

                        case "14":
                            #region Demotrium Dragon Chestplate
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Chestplate price is {demotriumDragonChestplate.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {demotriumDragonChestplate.name} ?");
                            Console.WriteLine("1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= demotriumDragonChestplate.price && demotriumDragonChestplate.equiped == false)
                                    {
                                        player1.coins -= demotriumDragonChestplate.price;
                                        demotriumDragonChestplate.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Chestplate bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        chestplateBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < demotriumDragonChestplate.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {demotriumDragonChestplate.name} price is {demotriumDragonChestplate.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this Chestplate
                                    else if (demotriumDragonChestplate.equiped)
                                    {
                                        Console.WriteLine("error, you already own this chestplate");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this Chestplate
                                    #region Calculation
                                    if (demotriumDragonChestplate.equiped)
                                    {
                                        chestplateEquipment.hp = 0;
                                        chestplateEquipment.dmg = 0;
                                        chestplateEquipment.def = 0;
                                        chestplateEquipment.hp = demotriumDragonChestplate.health;
                                        chestplateEquipment.dmg = demotriumDragonChestplate.damage;
                                        chestplateEquipment.def = demotriumDragonChestplate.defense;
                                        equipmentStats = false;
                                        #region other Chestplate unequip
                                        leatherChestplate.equiped = false;
                                        copperChestplate.equiped = false;
                                        bronzeChestplate.equiped = false;
                                        ironChestplate.equiped = false;
                                        steelChestplate.equiped = false;
                                        dwarvenChestplate.equiped = false;
                                        orcishChestplate.equiped = false;
                                        steelOrcishChestplate.equiped = false;
                                        ebonyChestplate.equiped = false;
                                        dragonBoneChestplate.equiped = false;
                                        teathriumChestplate.equiped = false;
                                        dragonplateChestplate.equiped = false;
                                        ancientTeathriumChestplate.equiped = false;
                                        /*  demotriumDragonChestplate.equiped = false;*/
                                        #endregion other Chestplate unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    chestplateBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Demotrium Dragon Helmet
                            break;

                        #endregion all Chestplates

                        case "15":
                            chestplateBuyMenu = true;

                            break;
                        default:
                            Console.WriteLine($"chestplate {chestplateBuyChoice} does not exist, try again");
                            break;
                    }

                }

                #endregion Chestplate shop buy
            }
            #endregion Chestplate shop Functions

            #region Gloves shop Functions
            void GlovesShop()
            {
                #region Gloves shop main menu
                Console.Clear();
                Console.WriteLine("Welcome to glove shop\nWhat do you want to do?\n1)buy Gloves\n2)Show Gloves prices\n3)back to shop");
                string glovesShopChoices = Console.ReadLine();
                switch (glovesShopChoices)
                {
                    case "1":
                        GlovesBuyMenu();
                        break;
                    case "2":
                        GlovesPriceMenu();
                        break;
                    default:
                        Console.WriteLine($"error choice {glovesShopChoices} was not found, please try again");
                        break;
                }
                #endregion Gloves shop main menu
            }

            void GlovesPriceMenu()
            {
                #region  Gloves price info menu
                string glovesPriceMenuPage = "1";

                bool glovesPriceMenu = true;
                while (glovesPriceMenu)
                {
                    Console.Clear();

                    switch (glovesPriceMenuPage)
                    {

                        case "1":

                            #region  Gloves price info page 1
                            Console.Clear();
                            leatherGloves.PrintOutPrice();
                            copperGloves.PrintOutPrice();
                            bronzeGloves.PrintOutPrice();
                            ironGloves.PrintOutPrice();
                            steelGloves.PrintOutPrice();
                            dwarvenGloves.PrintOutPrice();
                            orcishGloves.PrintOutPrice();
                            steelOrcishGloves.PrintOutPrice();
                            ebonyGloves.PrintOutPrice();
                            Console.WriteLine($"2)go to page 2\n3)back to gloves shop");
                            glovesPriceMenuPage = Console.ReadLine();
                            #endregion Gloves price info page 1
                            break;
                        case "2":

                            #region Gloves price info page 2
                            Console.Clear();
                            dragonBoneGloves.PrintOutPrice();
                            teathriumGloves.PrintOutPrice();
                            dragonplateGloves.PrintOutPrice();
                            ancientTeathriumGloves.PrintOutPrice();
                            demotriumDragonGloves.PrintOutPrice();
                            Console.WriteLine($"\n1)go to page 1\n3)back to gloves shop");
                            glovesPriceMenuPage = Console.ReadLine();
                            #endregion Gloves price info page 2
                            break;
                        case "3":
                            glovesPriceMenu = false;
                            break;
                        default:
                            Console.WriteLine($"error page {glovesPriceMenuPage} not found");
                            glovesPriceMenu = false;
                            Console.ReadLine();
                            break;
                    }





                }
                #endregion chestplate price info menu
            }

            void GlovesBuyMenu()
            {
                #region Gloves shop buy
                bool glovesBuyMenu = false;
                while (glovesBuyMenu == false)
                {
                    #region Buy Menu
                    Console.Clear();
                    Console.WriteLine("What Chestplate you want to buy?:");
                    Console.WriteLine($"1){leatherGloves.name}\n2){copperGloves.name}\n3){bronzeGloves.name}\n4){ironGloves.name}\n5){steelGloves.name}");
                    Console.WriteLine($"6){dwarvenGloves.name}\n7){orcishGloves.name}\n8){steelOrcishGloves.name}\n9){ebonyGloves.name}\n10){dragonBoneGloves.name}");
                    Console.WriteLine($"11){teathriumGloves.name}\n12){dragonplateGloves.name}\n13){ancientTeathriumGloves.name}\n14){demotriumDragonGloves.name}\n\n15)Back to Shop");
                    string glovesBuyChoice = Console.ReadLine();
                    #endregion Buy Menu
                    switch (glovesBuyChoice)
                    {
                        #region all Gloves
                        case "1":
                            #region Leather Gloves
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Gloves price is {leatherGloves.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {leatherGloves.name} ?");
                            Console.WriteLine($"1)yes\n2)no, back to Shop");
                            string buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= leatherGloves.price && leatherGloves.equiped == false)
                                    {
                                        player1.coins -= leatherGloves.price;
                                        leatherGloves.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Gloves bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        glovesBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < leatherGloves.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {leatherGloves.name} price is {leatherGloves.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this Gloves
                                    else if (leatherGloves.equiped)
                                    {
                                        Console.WriteLine("error, you already own this gloves");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this Chestplate
                                    #region Calculation
                                    if (leatherGloves.equiped)
                                    {
                                        glovesEquipment.hp = 0;
                                        glovesEquipment.dmg = 0;
                                        glovesEquipment.def = 0;
                                        glovesEquipment.hp = leatherGloves.health;
                                        glovesEquipment.dmg = leatherGloves.damage;
                                        glovesEquipment.def = leatherGloves.defense;
                                        equipmentStats = false;
                                        #region other Gloves unequip
                                        /*leatherGloves.equiped = false;*/
                                        copperGloves.equiped = false;
                                        bronzeGloves.equiped = false;
                                        ironGloves.equiped = false;
                                        steelGloves.equiped = false;
                                        dwarvenGloves.equiped = false;
                                        orcishGloves.equiped = false;
                                        steelOrcishGloves.equiped = false;
                                        ebonyGloves.equiped = false;
                                        dragonBoneGloves.equiped = false;
                                        teathriumGloves.equiped = false;
                                        dragonplateGloves.equiped = false;
                                        ancientTeathriumGloves.equiped = false;
                                        demotriumDragonGloves.equiped = false;
                                        #endregion other Gloves unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    glovesBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Leather Chestplate
                            break;

                        case "2":
                            #region Copper Gloves
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Gloves price is {copperGloves.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {copperGloves.name} ?");
                            Console.WriteLine("1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= copperGloves.price && copperGloves.equiped == false)
                                    {
                                        player1.coins -= copperGloves.price;
                                        copperGloves.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Gloves bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        glovesBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < copperGloves.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {copperGloves.name} price is {copperGloves.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this Chestplate
                                    else if (copperGloves.equiped)
                                    {
                                        Console.WriteLine("error, you already own this gloves");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this helmet
                                    #region Calculation
                                    if (copperGloves.equiped)
                                    {
                                        glovesEquipment.hp = 0;
                                        glovesEquipment.dmg = 0;
                                        glovesEquipment.def = 0;
                                        glovesEquipment.hp = copperGloves.health;
                                        glovesEquipment.dmg = copperGloves.damage;
                                        glovesEquipment.def = copperGloves.defense;
                                        equipmentStats = false;
                                        #region other Gloves unequip
                                        leatherGloves.equiped = false;
                                        /* copperGloves.equiped = false;*/
                                        bronzeGloves.equiped = false;
                                        ironGloves.equiped = false;
                                        steelGloves.equiped = false;
                                        dwarvenGloves.equiped = false;
                                        orcishGloves.equiped = false;
                                        steelOrcishGloves.equiped = false;
                                        ebonyGloves.equiped = false;
                                        dragonBoneGloves.equiped = false;
                                        teathriumGloves.equiped = false;
                                        dragonplateGloves.equiped = false;
                                        ancientTeathriumGloves.equiped = false;
                                        demotriumDragonGloves.equiped = false;
                                        #endregion other Gloves unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    glovesBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Copper Gloves
                            break;

                        case "3":
                            #region Bronze Gloves
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Gloves price is {bronzeGloves.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {bronzeGloves.name} ?");
                            Console.WriteLine("1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= bronzeGloves.price && bronzeGloves.equiped == false)
                                    {
                                        player1.coins -= bronzeGloves.price;
                                        bronzeGloves.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Gloves bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        glovesBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < bronzeGloves.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {bronzeGloves.name} price is {bronzeGloves.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this Gloves
                                    else if (bronzeGloves.equiped)
                                    {
                                        Console.WriteLine("error, you already own this gloves");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this Gloves
                                    #region Calculation
                                    if (bronzeGloves.equiped)
                                    {
                                        glovesEquipment.hp = 0;
                                        glovesEquipment.dmg = 0;
                                        glovesEquipment.def = 0;
                                        glovesEquipment.hp = bronzeGloves.health;
                                        glovesEquipment.dmg = bronzeGloves.damage;
                                        glovesEquipment.def = bronzeGloves.defense;
                                        equipmentStats = false;
                                        #region other Gloves unequip
                                        leatherGloves.equiped = false;
                                        copperGloves.equiped = false;
                                        /* bronzeGloves.equiped = false;*/
                                        ironGloves.equiped = false;
                                        steelGloves.equiped = false;
                                        dwarvenGloves.equiped = false;
                                        orcishGloves.equiped = false;
                                        steelOrcishGloves.equiped = false;
                                        ebonyGloves.equiped = false;
                                        dragonBoneGloves.equiped = false;
                                        teathriumGloves.equiped = false;
                                        dragonplateGloves.equiped = false;
                                        ancientTeathriumGloves.equiped = false;
                                        demotriumDragonGloves.equiped = false;
                                        #endregion other Gloves unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    glovesBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Bronze Chestplate
                            break;

                        case "4":
                            #region Iron Gloves
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Gloves price is {ironGloves.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {ironGloves.name} ?");
                            Console.WriteLine("1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= ironGloves.price && ironGloves.equiped == false)
                                    {
                                        player1.coins -= ironGloves.price;
                                        ironGloves.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Gloves bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        glovesBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < ironGloves.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {ironGloves.name} price is {ironGloves.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this Gloves
                                    else if (ironGloves.equiped)
                                    {
                                        Console.WriteLine("error, you already own this gloves");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this Gloves
                                    #region Calculation
                                    if (ironGloves.equiped)
                                    {
                                        glovesEquipment.hp = 0;
                                        glovesEquipment.dmg = 0;
                                        glovesEquipment.def = 0;
                                        glovesEquipment.hp = ironGloves.health;
                                        glovesEquipment.dmg = ironGloves.damage;
                                        glovesEquipment.def = ironGloves.defense;
                                        equipmentStats = false;
                                        #region other Gloves unequip
                                        leatherGloves.equiped = false;
                                        copperGloves.equiped = false;
                                        bronzeGloves.equiped = false;
                                        /*  ironGloves.equiped = false;*/
                                        steelGloves.equiped = false;
                                        dwarvenGloves.equiped = false;
                                        orcishGloves.equiped = false;
                                        steelOrcishGloves.equiped = false;
                                        ebonyGloves.equiped = false;
                                        dragonBoneGloves.equiped = false;
                                        teathriumGloves.equiped = false;
                                        dragonplateGloves.equiped = false;
                                        ancientTeathriumGloves.equiped = false;
                                        demotriumDragonGloves.equiped = false;
                                        #endregion other Gloves unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    glovesBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Iron Chestplate
                            break;

                        case "5":
                            #region Steel Gloves
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Gloves price is {steelGloves.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {steelGloves.name} ?");
                            Console.WriteLine("1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= steelGloves.price && steelGloves.equiped == false)
                                    {
                                        player1.coins -= steelGloves.price;
                                        steelGloves.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Gloves bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        glovesBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < steelGloves.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {steelGloves.name} price is {steelGloves.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this Gloves
                                    else if (steelGloves.equiped)
                                    {
                                        Console.WriteLine("error, you already own this gloves");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this Gloves
                                    #region Calculation
                                    if (steelGloves.equiped)
                                    {
                                        glovesEquipment.hp = 0;
                                        glovesEquipment.dmg = 0;
                                        glovesEquipment.def = 0;
                                        glovesEquipment.hp = steelGloves.health;
                                        glovesEquipment.dmg = steelGloves.damage;
                                        glovesEquipment.def = steelGloves.defense;
                                        equipmentStats = false;
                                        #region other Gloves unequip
                                        leatherGloves.equiped = false;
                                        copperGloves.equiped = false;
                                        bronzeGloves.equiped = false;
                                        ironGloves.equiped = false;
                                        /*  steelGloves.equiped = false;*/
                                        dwarvenGloves.equiped = false;
                                        orcishGloves.equiped = false;
                                        steelOrcishGloves.equiped = false;
                                        ebonyGloves.equiped = false;
                                        dragonBoneGloves.equiped = false;
                                        teathriumGloves.equiped = false;
                                        dragonplateGloves.equiped = false;
                                        ancientTeathriumGloves.equiped = false;
                                        demotriumDragonGloves.equiped = false;
                                        #endregion other Gloves unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    glovesBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Steel Gloves
                            break;

                        case "6":
                            #region Dwarven Gloves
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Gloves price is {dwarvenGloves.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {dwarvenGloves.name} ?");
                            Console.WriteLine("1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= dwarvenGloves.price && dwarvenGloves.equiped == false)
                                    {
                                        player1.coins -= dwarvenGloves.price;
                                        dwarvenGloves.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Gloves bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        glovesBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < dwarvenGloves.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {dwarvenGloves.name} price is {dwarvenGloves.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this Gloves
                                    else if (dwarvenGloves.equiped)
                                    {
                                        Console.WriteLine("error, you already own this gloves");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this Gloves
                                    #region Calculation
                                    if (dwarvenGloves.equiped)
                                    {
                                        glovesEquipment.hp = 0;
                                        glovesEquipment.dmg = 0;
                                        glovesEquipment.def = 0;
                                        glovesEquipment.hp = dwarvenGloves.health;
                                        glovesEquipment.dmg = dwarvenGloves.damage;
                                        glovesEquipment.def = dwarvenGloves.defense;
                                        equipmentStats = false;
                                        #region other Gloves unequip
                                        leatherGloves.equiped = false;
                                        copperGloves.equiped = false;
                                        bronzeGloves.equiped = false;
                                        ironGloves.equiped = false;
                                        steelGloves.equiped = false;
                                        /*  dwarvenGloves.equiped = false;*/
                                        orcishGloves.equiped = false;
                                        steelOrcishGloves.equiped = false;
                                        ebonyGloves.equiped = false;
                                        dragonBoneGloves.equiped = false;
                                        teathriumGloves.equiped = false;
                                        dragonplateGloves.equiped = false;
                                        ancientTeathriumGloves.equiped = false;
                                        demotriumDragonGloves.equiped = false;
                                        #endregion other Gloves unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    glovesBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Dwarven Chestplate
                            break;

                        case "7":
                            #region Orcish Gloves
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Gloves  price is {orcishGloves.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {orcishGloves.name} ?");
                            Console.WriteLine("1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= orcishGloves.price && orcishGloves.equiped == false)
                                    {
                                        player1.coins -= orcishGloves.price;
                                        orcishGloves.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Gloves  bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        glovesBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < orcishGloves.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {orcishGloves.name} price is {orcishGloves.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this Gloves
                                    else if (orcishChestplate.equiped)
                                    {
                                        Console.WriteLine("error, you already own this gloves");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this Gloves
                                    #region Calculation
                                    if (orcishGloves.equiped)
                                    {
                                        glovesEquipment.hp = 0;
                                        glovesEquipment.dmg = 0;
                                        glovesEquipment.def = 0;
                                        glovesEquipment.hp = orcishGloves.health;
                                        glovesEquipment.dmg = orcishGloves.damage;
                                        glovesEquipment.def = orcishGloves.defense;
                                        equipmentStats = false;
                                        #region other Gloves unequip
                                        leatherGloves.equiped = false;
                                        copperGloves.equiped = false;
                                        bronzeGloves.equiped = false;
                                        ironGloves.equiped = false;
                                        steelGloves.equiped = false;
                                        dwarvenGloves.equiped = false;
                                        /*orcishGloves.equiped = false;*/
                                        steelOrcishGloves.equiped = false;
                                        ebonyGloves.equiped = false;
                                        dragonBoneGloves.equiped = false;
                                        teathriumGloves.equiped = false;
                                        dragonplateGloves.equiped = false;
                                        ancientTeathriumGloves.equiped = false;
                                        demotriumDragonGloves.equiped = false;
                                        #endregion other Gloves unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    glovesBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Orcish Gloves
                            break;

                        case "8":
                            #region Steel orcish Gloves
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Gloves price is {steelOrcishGloves.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {steelOrcishGloves.name} ?");
                            Console.WriteLine("1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= steelOrcishGloves.price && steelOrcishGloves.equiped == false)
                                    {
                                        player1.coins -= steelOrcishGloves.price;
                                        steelOrcishGloves.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Gloves bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        glovesBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < steelOrcishGloves.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {steelOrcishGloves.name} price is {steelOrcishGloves.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this Gloves
                                    else if (steelOrcishGloves.equiped)
                                    {
                                        Console.WriteLine("error, you already own this gloves");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this Gloves
                                    #region Calculation
                                    if (steelOrcishGloves.equiped)
                                    {
                                        glovesEquipment.hp = 0;
                                        glovesEquipment.dmg = 0;
                                        glovesEquipment.def = 0;
                                        glovesEquipment.hp = steelOrcishGloves.health;
                                        glovesEquipment.dmg = steelOrcishGloves.damage;
                                        glovesEquipment.def = steelOrcishGloves.defense;
                                        equipmentStats = false;
                                        #region other Gloves unequip
                                        leatherGloves.equiped = false;
                                        copperGloves.equiped = false;
                                        bronzeGloves.equiped = false;
                                        ironGloves.equiped = false;
                                        steelGloves.equiped = false;
                                        dwarvenGloves.equiped = false;
                                        orcishGloves.equiped = false;
                                        /* steelOrcishGloves.equiped = false;*/
                                        ebonyGloves.equiped = false;
                                        dragonBoneGloves.equiped = false;
                                        teathriumGloves.equiped = false;
                                        dragonplateGloves.equiped = false;
                                        ancientTeathriumGloves.equiped = false;
                                        demotriumDragonGloves.equiped = false;
                                        #endregion other Gloves unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    glovesBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Steel orcish Chestplate
                            break;

                        case "9":
                            #region Ebony Gloves
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Gloves price is {ebonyGloves.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {ebonyGloves.name} ?");
                            Console.WriteLine("1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= ebonyGloves.price && ebonyGloves.equiped == false)
                                    {
                                        player1.coins -= ebonyGloves.price;
                                        ebonyGloves.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Gloves bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        glovesBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < ebonyGloves.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {ebonyHelmet.name} price is {ebonyGloves.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this Gloves
                                    else if (ebonyGloves.equiped)
                                    {
                                        Console.WriteLine("error, you already own this gloves");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this Chestplate
                                    #region Calculation
                                    if (ebonyGloves.equiped)
                                    {
                                        glovesEquipment.hp = 0;
                                        glovesEquipment.dmg = 0;
                                        glovesEquipment.def = 0;
                                        glovesEquipment.hp = ebonyGloves.health;
                                        glovesEquipment.dmg = ebonyGloves.damage;
                                        glovesEquipment.def = ebonyGloves.defense;
                                        equipmentStats = false;
                                        #region other Gloves unequip
                                        leatherGloves.equiped = false;
                                        copperGloves.equiped = false;
                                        bronzeGloves.equiped = false;
                                        ironGloves.equiped = false;
                                        steelGloves.equiped = false;
                                        dwarvenGloves.equiped = false;
                                        orcishGloves.equiped = false;
                                        steelOrcishGloves.equiped = false;
                                        /* ebonyGloves.equiped = false;*/
                                        dragonBoneGloves.equiped = false;
                                        teathriumGloves.equiped = false;
                                        dragonplateGloves.equiped = false;
                                        ancientTeathriumGloves.equiped = false;
                                        demotriumDragonGloves.equiped = false;
                                        #endregion other Gloves unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    glovesBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Ebony Gloves
                            break;

                        case "10":
                            #region Dragon Bone Gloves
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Gloves price is {dragonBoneGloves.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {dragonBoneGloves.name} ?");
                            Console.WriteLine("1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= dragonBoneGloves.price && dragonBoneGloves.equiped == false)
                                    {
                                        player1.coins -= dragonBoneGloves.price;
                                        dragonBoneGloves.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Gloves bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        glovesBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < dragonBoneGloves.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {dragonBoneGloves.name} price is {dragonBoneGloves.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this Gloves
                                    else if (dragonBoneGloves.equiped)
                                    {
                                        Console.WriteLine("error, you already own this gloves");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this Gloves
                                    #region Calculation
                                    if (dragonBoneGloves.equiped)
                                    {
                                        glovesEquipment.hp = 0;
                                        glovesEquipment.dmg = 0;
                                        glovesEquipment.def = 0;
                                        glovesEquipment.hp = dragonBoneGloves.health;
                                        glovesEquipment.dmg = dragonBoneGloves.damage;
                                        glovesEquipment.def = dragonBoneGloves.defense;
                                        equipmentStats = false;
                                        #region other Gloves unequip
                                        leatherGloves.equiped = false;
                                        copperGloves.equiped = false;
                                        bronzeGloves.equiped = false;
                                        ironGloves.equiped = false;
                                        steelGloves.equiped = false;
                                        dwarvenGloves.equiped = false;
                                        orcishGloves.equiped = false;
                                        steelOrcishGloves.equiped = false;
                                        ebonyGloves.equiped = false;
                                        /* dragonBoneGloves.equiped = false;*/
                                        teathriumGloves.equiped = false;
                                        dragonplateGloves.equiped = false;
                                        ancientTeathriumGloves.equiped = false;
                                        demotriumDragonGloves.equiped = false;
                                        #endregion other Gloves unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    glovesBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Dragon Bone Gloves
                            break;

                        case "11":
                            #region Teathrium Gloves
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Gloves price is {teathriumGloves.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {teathriumGloves.name} ?");
                            Console.WriteLine("1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= teathriumGloves.price && teathriumGloves.equiped == false)
                                    {
                                        player1.coins -= teathriumGloves.price;
                                        teathriumGloves.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Gloves bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        glovesBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < teathriumGloves.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {teathriumGloves.name} price is {teathriumGloves.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this Gloves
                                    else if (teathriumGloves.equiped)
                                    {
                                        Console.WriteLine("error, you already own this gloves");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this Gloves
                                    #region Calculation
                                    if (teathriumGloves.equiped)
                                    {
                                        glovesEquipment.hp = 0;
                                        glovesEquipment.dmg = 0;
                                        glovesEquipment.def = 0;
                                        glovesEquipment.hp = teathriumGloves.health;
                                        glovesEquipment.dmg = teathriumGloves.damage;
                                        glovesEquipment.def = teathriumGloves.defense;
                                        equipmentStats = false;
                                        #region other Gloves unequip
                                        leatherGloves.equiped = false;
                                        copperGloves.equiped = false;
                                        bronzeGloves.equiped = false;
                                        ironGloves.equiped = false;
                                        steelGloves.equiped = false;
                                        dwarvenGloves.equiped = false;
                                        orcishGloves.equiped = false;
                                        steelOrcishGloves.equiped = false;
                                        ebonyGloves.equiped = false;
                                        dragonBoneGloves.equiped = false;
                                        /*teathriumGloves.equiped = false;*/
                                        dragonplateGloves.equiped = false;
                                        ancientTeathriumGloves.equiped = false;
                                        demotriumDragonGloves.equiped = false;
                                        #endregion other Gloves unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    glovesBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Teathrium Chestplate
                            break;

                        case "12":
                            #region Dragon Plate Gloves
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Gloves price is {dragonplateGloves.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {dragonplateGloves.name} ?");
                            Console.WriteLine("1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= dragonplateGloves.price && dragonplateGloves.equiped == false)
                                    {
                                        player1.coins -= dragonplateGloves.price;
                                        dragonplateGloves.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Gloves bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        glovesBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < dragonplateGloves.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {dragonplateGloves.name} price is {dragonplateGloves.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this Gloves
                                    else if (dragonplateGloves.equiped)
                                    {
                                        Console.WriteLine("error, you already own this gloves");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this Gloves
                                    #region Calculation
                                    if (dragonplateGloves.equiped)
                                    {
                                        glovesEquipment.hp = 0;
                                        glovesEquipment.dmg = 0;
                                        glovesEquipment.def = 0;
                                        glovesEquipment.hp = dragonplateGloves.health;
                                        glovesEquipment.dmg = dragonplateGloves.damage;
                                        glovesEquipment.def = dragonplateGloves.defense;
                                        equipmentStats = false;
                                        #region other Gloves unequip
                                        leatherGloves.equiped = false;
                                        copperGloves.equiped = false;
                                        bronzeGloves.equiped = false;
                                        ironGloves.equiped = false;
                                        steelGloves.equiped = false;
                                        dwarvenGloves.equiped = false;
                                        orcishGloves.equiped = false;
                                        steelOrcishGloves.equiped = false;
                                        ebonyGloves.equiped = false;
                                        dragonBoneGloves.equiped = false;
                                        teathriumGloves.equiped = false;
                                        /*dragonplateGloves.equiped = false;*/
                                        ancientTeathriumGloves.equiped = false;
                                        demotriumDragonGloves.equiped = false;
                                        #endregion other Gloves unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    glovesBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Dragon Plate Chestplate
                            break;

                        case "13":
                            #region Ancient Teathrium Gloves
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Gloves price is {ancientTeathriumGloves.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {ancientTeathriumGloves.name} ?");
                            Console.WriteLine("1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= ancientTeathriumGloves.price && ancientTeathriumGloves.equiped == false)
                                    {
                                        player1.coins -= ancientTeathriumGloves.price;
                                        ancientTeathriumGloves.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Gloves bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        glovesBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < ancientTeathriumGloves.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {ancientTeathriumGloves.name} price is {ancientTeathriumGloves.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this Gloves
                                    else if (ancientTeathriumGloves.equiped)
                                    {
                                        Console.WriteLine("error, you already own this gloves");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this Gloves
                                    #region Calculation
                                    if (ancientTeathriumGloves.equiped)
                                    {
                                        glovesEquipment.hp = 0;
                                        glovesEquipment.dmg = 0;
                                        glovesEquipment.def = 0;
                                        glovesEquipment.hp = ancientTeathriumGloves.health;
                                        glovesEquipment.dmg = ancientTeathriumGloves.damage;
                                        glovesEquipment.def = ancientTeathriumGloves.defense;
                                        equipmentStats = false;
                                        #region other Gloves unequip
                                        leatherGloves.equiped = false;
                                        copperGloves.equiped = false;
                                        bronzeGloves.equiped = false;
                                        ironGloves.equiped = false;
                                        steelGloves.equiped = false;
                                        dwarvenGloves.equiped = false;
                                        orcishGloves.equiped = false;
                                        steelOrcishGloves.equiped = false;
                                        ebonyGloves.equiped = false;
                                        dragonBoneGloves.equiped = false;
                                        teathriumGloves.equiped = false;
                                        dragonplateGloves.equiped = false;
                                        /* ancientTeathriumGloves.equiped = false;*/
                                        demotriumDragonGloves.equiped = false;
                                        #endregion other Gloves unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    glovesBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Ancient teathrium Gloves
                            break;

                        case "14":
                            #region Demotrium Dragon Gloves
                            #region Buy Confirmation
                            Console.Clear();
                            Console.WriteLine($"Gloves price is {demotriumDragonGloves.price} Kricoins and you have {player1.coins} Kricoins\nAre you sure you want to buy {demotriumDragonGloves.name} ?");
                            Console.WriteLine("1)yes\n2)no, back to Shop");
                            buyConfirmation = Console.ReadLine();
                            #endregion Buy Confirmation
                            switch (buyConfirmation)
                            {
                                case "1":
                                    #region Buy Function
                                    #region Player can Buy
                                    if (player1.coins >= demotriumDragonGloves.price && demotriumDragonGloves.equiped == false)
                                    {
                                        player1.coins -= demotriumDragonGloves.price;
                                        demotriumDragonGloves.equiped = true;
                                        Console.Clear();
                                        Console.WriteLine($"Gloves bought successfully\nYou currently have {player1.coins} Kricoins left");
                                        Console.ReadLine();
                                        glovesBuyMenu = true;

                                    }


                                    #endregion Player can Buy
                                    #region Player dont have enough money
                                    else if (player1.coins < demotriumDragonGloves.price)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"error {demotriumDragonGloves.name} price is {demotriumDragonGloves.price} Kricoins, but you only have {player1.coins} Kricoins\nnot enough money");
                                        Console.ReadLine();
                                    }
                                    #endregion Player dont have enough money
                                    #region Player already own this Gloves
                                    else if (demotriumDragonGloves.equiped)
                                    {
                                        Console.WriteLine("error, you already own this gloves");
                                        Console.ReadLine();
                                    }
                                    #endregion Player already own this Chestplate
                                    #region Calculation
                                    if (demotriumDragonGloves.equiped)
                                    {
                                        glovesEquipment.hp = 0;
                                        glovesEquipment.dmg = 0;
                                        glovesEquipment.def = 0;
                                        glovesEquipment.hp = demotriumDragonGloves.health;
                                        glovesEquipment.dmg = demotriumDragonGloves.damage;
                                        glovesEquipment.def = demotriumDragonGloves.defense;
                                        equipmentStats = false;
                                        #region other Gloves unequip
                                        leatherGloves.equiped = false;
                                        copperGloves.equiped = false;
                                        bronzeGloves.equiped = false;
                                        ironGloves.equiped = false;
                                        steelGloves.equiped = false;
                                        dwarvenGloves.equiped = false;
                                        orcishGloves.equiped = false;
                                        steelOrcishGloves.equiped = false;
                                        ebonyGloves.equiped = false;
                                        dragonBoneGloves.equiped = false;
                                        teathriumGloves.equiped = false;
                                        dragonplateGloves.equiped = false;
                                        ancientTeathriumGloves.equiped = false;
                                        /* demotriumDragonGloves.equiped = false;*/
                                        #endregion other Gloves unequip

                                    }
                                    #endregion Calculation


                                    #endregion Buy Function
                                    break;
                                case "2":
                                    glovesBuyMenu = true;
                                    break;
                                default:

                                    Console.WriteLine("Unexpected error occurred, please try again");
                                    Console.ReadLine();
                                    break;
                            }

                            #endregion Demotrium Dragon Gloves
                            break;

                        #endregion all Gloves

                        case "15":
                            glovesBuyMenu = true;

                            break;
                        default:
                            Console.WriteLine($"gloves {glovesBuyChoice} does not exist, try again");
                            break;
                    }

                }

                #endregion Gloves shop buy
            }
            #endregion Gloves shop Functions

            #region player info
            void PrintOutPlayerInfo()
            {
                if (helmetEquipment.name == "")
                {
                    helmetEquipment.name = "none";
                }
                Console.WriteLine($"Health:{player1.health}/{player1.maxHealth}\nDamage:{player1.minDmg}-{player1.maxDmg}\nDefense:{player1.defense}\nDexterity:{player1.dex}\nExperience:{player1.exp}\nKricoins:{player1.coins}\n\nWeapon:\nHelmet: {helmetEquipment.name}\nChestplate: {chestplateEquipment.name}\nGloves: {glovesEquipment.name}");
            }
            #endregion player info

        }//void main

    } //class program

} //namespace