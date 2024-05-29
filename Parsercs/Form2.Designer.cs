namespace Parsercs
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.autoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.database1DataSet1 = new Parsercs.Database1DataSet1();
            this.database1DataSet = new Parsercs.Database1DataSet();
            this.database1DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.autoTableAdapter = new Parsercs.Database1DataSet1TableAdapters.AutoTableAdapter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSetBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 402);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(973, 405);
            this.dataGridView1.TabIndex = 0;
            // 
            // autoBindingSource
            // 
            this.autoBindingSource.DataMember = "Auto";
            this.autoBindingSource.DataSource = this.database1DataSet1;
            // 
            // database1DataSet1
            // 
            this.database1DataSet1.DataSetName = "Database1DataSet1";
            this.database1DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // database1DataSet
            // 
            this.database1DataSet.DataSetName = "Database1DataSet";
            this.database1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // database1DataSetBindingSource
            // 
            this.database1DataSetBindingSource.DataSource = this.database1DataSet;
            this.database1DataSetBindingSource.Position = 0;
            // 
            // autoTableAdapter
            // 
            this.autoTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.comboBox4);
            this.groupBox1.Controls.Add(this.comboBox5);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 11.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(0, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1103, 827);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Парсер";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.Location = new System.Drawing.Point(780, 338);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 33);
            this.button1.TabIndex = 9;
            this.button1.Text = "Фильтровать";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.Info;
            this.comboBox1.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Абаза",
            "Абакан",
            "Абдулино",
            "Абинск",
            "Агидель",
            "Агрыз",
            "Адыгейск",
            "Азнакаево",
            "Азов",
            "Ак-Довурак",
            "Аксай",
            "Алагир",
            "Алапаевск",
            "Алатырь",
            "Алдан",
            "Алейск",
            "Александров",
            "Александровск",
            "Александровск-Сахалинский",
            "Алексеевка",
            "Алексин",
            "Алзамай",
            "Алупка",
            "Алушта",
            "Альметьевск",
            "Амурск",
            "Анадырь",
            "Анапа",
            "Ангарск",
            "Андреаполь",
            "Анжеро-Судженск",
            "Анива",
            "Апатиты",
            "Апрелевка",
            "Апшеронск",
            "Арамиль",
            "Аргун",
            "Ардатов",
            "Ардон",
            "Арзамас",
            "Аркадак",
            "Армавир",
            "Армянск",
            "Арсеньев",
            "Арск",
            "Артём",
            "Артёмовск",
            "Артёмовский",
            "Архангельск",
            "Асбест",
            "Асино",
            "Астрахань",
            "Аткарск",
            "Ахтубинск",
            "Ачинск",
            "Аша",
            "Бабаево",
            "Бабушкин",
            "Бавлы",
            "Багратионовск",
            "Байкальск",
            "Баймак",
            "Бакал",
            "Баксан",
            "Балабаново",
            "Балаково",
            "Балахна",
            "Балашиха",
            "Балашов",
            "Балей",
            "Балтийск",
            "Барабинск",
            "Барнаул",
            "Барыш",
            "Батайск",
            "Бахчисарай",
            "Бежецк",
            "Белая Калитва",
            "Белая Холуница",
            "Белгород",
            "Белебей",
            "Белёв",
            "Белинский",
            "Белово",
            "Белогорск",
            "Белогорск",
            "Белозерск",
            "Белокуриха",
            "Беломорск",
            "Белоозёрский",
            "Белорецк",
            "Белореченск",
            "Белоусово",
            "Белоярский",
            "Белый",
            "Бердск",
            "Березники",
            "Берёзовский",
            "Берёзовский",
            "Беслан",
            "Бийск",
            "Бикин",
            "Билибино",
            "Биробиджан",
            "Бирск",
            "Бирюсинск",
            "Бирюч",
            "Благовещенск",
            "Благовещенск",
            "Благодарный",
            "Бобров",
            "Богданович",
            "Богородицк",
            "Богородск",
            "Боготол",
            "Богучар",
            "Бодайбо",
            "Бокситогорск",
            "Болгар",
            "Бологое",
            "Болотное",
            "Болохово",
            "Болхов",
            "Большой Камень",
            "Бор",
            "Борзя",
            "Борисоглебск",
            "Боровичи",
            "Боровск",
            "Бородино",
            "Братск",
            "Бронницы",
            "Брянск",
            "Бугульма",
            "Бугуруслан",
            "Будённовск",
            "Бузулук",
            "Буинск",
            "Буй",
            "Буйнакск",
            "Бутурлиновка",
            "Валдай",
            "Валуйки",
            "Велиж",
            "Великие Луки",
            "Великий Новгород",
            "Великий Устюг",
            "Вельск",
            "Венёв",
            "Верещагино",
            "Верея",
            "Верхнеуральск",
            "Верхний Тагил",
            "Верхний Уфалей",
            "Верхняя Пышма",
            "Верхняя Салда",
            "Верхняя Тура",
            "Верхотурье",
            "Верхоянск",
            "Весьегонск",
            "Ветлуга",
            "Видное",
            "Вилюйск",
            "Вилючинск",
            "Вихоревка",
            "Вичуга",
            "Владивосток",
            "Владикавказ",
            "Владимир",
            "Волгоград",
            "Волгодонск",
            "Волгореченск",
            "Волжск",
            "Волжский",
            "Вологда",
            "Володарск",
            "Волоколамск",
            "Волосово",
            "Волхов",
            "Волчанск",
            "Вольск",
            "Воркута",
            "Воронеж",
            "Ворсма",
            "Воскресенск",
            "Воткинск",
            "Всеволожск",
            "Вуктыл",
            "Выборг",
            "Выкса",
            "Высоковск",
            "Высоцк",
            "Вытегра",
            "Вышний Волочёк",
            "Вяземский",
            "Вязники",
            "Вязьма",
            "Вятские Поляны",
            "Гаврилов Посад",
            "Гаврилов-Ям",
            "Гагарин",
            "Гаджиево",
            "Гай",
            "Галич",
            "Гатчина",
            "Гвардейск",
            "Гдов",
            "Геленджик",
            "Георгиевск",
            "Глазов",
            "Голицыно",
            "Горбатов",
            "Горно-Алтайск",
            "Горнозаводск",
            "Горняк",
            "Городец",
            "Городище",
            "Городовиковск",
            "Гороховец",
            "Горячий Ключ",
            "Грайворон",
            "Гремячинск",
            "Грозный",
            "Грязи",
            "Грязовец",
            "Губаха",
            "Губкин",
            "Губкинский",
            "Гудермес",
            "Гуково",
            "Гулькевичи",
            "Гурьевск",
            "Гурьевск",
            "Гусев",
            "Гусиноозёрск",
            "Гусь-Хрустальный",
            "Давлеканово",
            "Дагестанские Огни",
            "Далматово",
            "Дальнегорск",
            "Дальнереченск",
            "Данилов",
            "Данков",
            "Дегтярск",
            "Дедовск",
            "Демидов",
            "Дербент",
            "Десногорск",
            "Джанкой",
            "Дзержинск",
            "Дзержинский",
            "Дивногорск",
            "Дигора",
            "Димитровград",
            "Дмитриев",
            "Дмитров",
            "Дмитровск",
            "Дно",
            "Добрянка",
            "Долгопрудный",
            "Долинск",
            "Домодедово",
            "Донецк",
            "Донской",
            "Дорогобуж",
            "Дрезна",
            "Дубна",
            "Дубовка",
            "Дудинка",
            "Духовщина",
            "Дюртюли",
            "Дятьково",
            "Евпатория",
            "Егорьевск",
            "Ейск",
            "Екатеринбург",
            "Елабуга",
            "Елец",
            "Елизово",
            "Ельня",
            "Еманжелинск",
            "Емва",
            "Енисейск",
            "Ермолино",
            "Ершов",
            "Ессентуки",
            "Ефремов",
            "Железноводск",
            "Железногорск",
            "Железногорск",
            "Железногорск-Илимский",
            "Жердевка",
            "Жигулёвск",
            "Жиздра",
            "Жирновск",
            "Жуков",
            "Жуковка",
            "Жуковский",
            "Завитинск",
            "Заводоуковск",
            "Заволжск",
            "Заволжье",
            "Задонск",
            "Заинск",
            "Закаменск",
            "Заозёрный",
            "Заозёрск",
            "Западная Двина",
            "Заполярный",
            "Зарайск",
            "Заречный",
            "Заречный",
            "Заринск",
            "Звенигово",
            "Звенигород",
            "Зверево",
            "Зеленогорск",
            "Зеленоградск",
            "Зеленодольск",
            "Зеленокумск",
            "Зерноград",
            "Зея",
            "Зима",
            "Златоуст",
            "Злынка",
            "Змеиногорск",
            "Знаменск",
            "Зубцов",
            "Зуевка",
            "Ивангород",
            "Иваново",
            "Ивантеевка",
            "Ивдель",
            "Игарка",
            "Ижевск",
            "Избербаш",
            "Изобильный",
            "Иланский",
            "Инза",
            "Иннополис",
            "Инсар",
            "Инта",
            "Ипатово",
            "Ирбит",
            "Иркутск",
            "Исилькуль",
            "Искитим",
            "Истра",
            "Ишим",
            "Ишимбай",
            "Йошкар-Ола",
            "Кадников",
            "Казань",
            "Калач",
            "Калач-на-Дону",
            "Калачинск",
            "Калининград",
            "Калининск",
            "Калтан",
            "Калуга",
            "Калязин",
            "Камбарка",
            "Каменка",
            "Каменногорск",
            "Каменск-Уральский",
            "Каменск-Шахтинский",
            "Камень-на-Оби",
            "Камешково",
            "Камызяк",
            "Камышин",
            "Камышлов",
            "Канаш",
            "Кандалакша",
            "Канск",
            "Карабаново",
            "Карабаш",
            "Карабулак",
            "Карасук",
            "Карачаевск",
            "Карачев",
            "Каргат",
            "Каргополь",
            "Карпинск",
            "Карталы",
            "Касимов",
            "Касли",
            "Каспийск",
            "Катав-Ивановск",
            "Катайск",
            "Качканар",
            "Кашин",
            "Кашира",
            "Кедровый",
            "Кемерово",
            "Кемь",
            "Керчь",
            "Кизел",
            "Кизилюрт",
            "Кизляр",
            "Кимовск",
            "Кимры",
            "Кингисепп",
            "Кинель",
            "Кинешма",
            "Киреевск",
            "Киренск",
            "Киржач",
            "Кириллов",
            "Кириши",
            "Киров",
            "Киров",
            "Кировград",
            "Кирово-Чепецк",
            "Кировск",
            "Кировск",
            "Кирс",
            "Кирсанов",
            "Киселёвск",
            "Кисловодск",
            "Клин",
            "Клинцы",
            "Княгинино",
            "Ковдор",
            "Ковров",
            "Ковылкино",
            "Когалым",
            "Кодинск",
            "Козельск",
            "Козловка",
            "Козьмодемьянск",
            "Кола",
            "Кологрив",
            "Коломна",
            "Колпашево",
            "Кольчугино",
            "Коммунар",
            "Комсомольск",
            "Комсомольск-на-Амуре",
            "Конаково",
            "Кондопога",
            "Кондрово",
            "Константиновск",
            "Копейск",
            "Кораблино",
            "Кореновск",
            "Коркино",
            "Королёв",
            "Короча",
            "Корсаков",
            "Коряжма",
            "Костерёво",
            "Костомукша",
            "Кострома",
            "Котельники",
            "Котельниково",
            "Котельнич",
            "Котлас",
            "Котово",
            "Котовск",
            "Кохма",
            "Красавино",
            "Красноармейск",
            "Красноармейск",
            "Красновишерск",
            "Красногорск",
            "Краснодар",
            "Краснозаводск",
            "Краснознаменск",
            "Краснознаменск",
            "Краснокаменск",
            "Краснокамск",
            "Красноперекопск",
            "Краснослободск",
            "Краснослободск",
            "Краснотурьинск",
            "Красноуральск",
            "Красноуфимск",
            "Красноярск",
            "Красный Кут",
            "Красный Сулин",
            "Красный Холм",
            "Кремёнки",
            "Кропоткин",
            "Крымск",
            "Кстово",
            "Кубинка",
            "Кувандык",
            "Кувшиново",
            "Кудрово",
            "Кудымкар",
            "Кузнецк",
            "Куйбышев",
            "Кукмор",
            "Кулебаки",
            "Кумертау",
            "Кунгур",
            "Купино",
            "Курган",
            "Курганинск",
            "Курильск",
            "Курлово",
            "Куровское",
            "Курск",
            "Куртамыш",
            "Курчалой",
            "Курчатов",
            "Куса",
            "Кушва",
            "Кызыл",
            "Кыштым",
            "Кяхта",
            "Лабинск",
            "Лабытнанги",
            "Лагань",
            "Ладушкин",
            "Лаишево",
            "Лакинск",
            "Лангепас",
            "Лахденпохья",
            "Лебедянь",
            "Лениногорск",
            "Ленинск",
            "Ленинск-Кузнецкий",
            "Ленск",
            "Лермонтов",
            "Лесной",
            "Лесозаводск",
            "Лесосибирск",
            "Ливны",
            "Ликино-Дулёво",
            "Липецк",
            "Липки",
            "Лиски",
            "Лихославль",
            "Лобня",
            "Лодейное Поле",
            "Лосино-Петровский",
            "Луга",
            "Луза",
            "Лукоянов",
            "Луховицы",
            "Лысково",
            "Лысьва",
            "Лыткарино",
            "Льгов",
            "Любань",
            "Люберцы",
            "Любим",
            "Людиново",
            "Лянтор",
            "Магадан",
            "Магас",
            "Магнитогорск",
            "Майкоп",
            "Майский",
            "Макаров",
            "Макарьев",
            "Макушино",
            "Малая Вишера",
            "Малгобек",
            "Малмыж",
            "Малоархангельск",
            "Малоярославец",
            "Мамадыш",
            "Мамоново",
            "Мантурово",
            "Мариинск",
            "Мариинский Посад",
            "Маркс",
            "Махачкала",
            "Мглин",
            "Мегион",
            "Медвежьегорск",
            "Медногорск",
            "Медынь",
            "Межгорье",
            "Междуреченск",
            "Мезень",
            "Меленки",
            "Мелеуз",
            "Менделеевск",
            "Мензелинск",
            "Мещовск",
            "Миасс",
            "Микунь",
            "Миллерово",
            "Минеральные Воды",
            "Минусинск",
            "Миньяр",
            "Мирный",
            "Мирный",
            "Михайлов",
            "Михайловка",
            "Михайловск",
            "Михайловск",
            "Мичуринск",
            "Могоча",
            "Можайск",
            "Можга",
            "Моздок",
            "Мончегорск",
            "Морозовск",
            "Моршанск",
            "Мосальск",
            "Москва",
            "Муравленко",
            "Мураши",
            "Мурино",
            "Мурманск",
            "Муром",
            "Мценск",
            "Мыски",
            "Мытищи",
            "Мышкин",
            "Набережные Челны",
            "Навашино",
            "Наволоки",
            "Надым",
            "Назарово",
            "Назрань",
            "Называевск",
            "Нальчик",
            "Нариманов",
            "Наро-Фоминск",
            "Нарткала",
            "Нарьян-Мар",
            "Находка",
            "Невель",
            "Невельск",
            "Невинномысск",
            "Невьянск",
            "Нелидово",
            "Неман",
            "Нерехта",
            "Нерчинск",
            "Нерюнгри",
            "Нестеров",
            "Нефтегорск",
            "Нефтекамск",
            "Нефтекумск",
            "Нефтеюганск",
            "Нея",
            "Нижневартовск",
            "Нижнекамск",
            "Нижнеудинск",
            "Нижние Серги",
            "Нижний Ломов",
            "Нижний Новгород",
            "Нижний Тагил",
            "Нижняя Салда",
            "Нижняя Тура",
            "Николаевск",
            "Николаевск-на-Амуре",
            "Никольск",
            "Никольск",
            "Никольское",
            "Новая Ладога",
            "Новая Ляля",
            "Новоалександровск",
            "Новоалтайск",
            "Новоаннинский",
            "Нововоронеж",
            "Новодвинск",
            "Новозыбков",
            "Новокубанск",
            "Новокузнецк",
            "Новокуйбышевск",
            "Новомичуринск",
            "Новомосковск",
            "Новопавловск",
            "Новоржев",
            "Новороссийск",
            "Новосибирск",
            "Новосиль",
            "Новосокольники",
            "Новотроицк",
            "Новоузенск",
            "Новоульяновск",
            "Новоуральск",
            "Новохопёрск",
            "Новочебоксарск",
            "Новочеркасск",
            "Новошахтинск",
            "Новый Оскол",
            "Новый Уренгой",
            "Ногинск",
            "Нолинск",
            "Норильск",
            "Ноябрьск",
            "Нурлат",
            "Нытва",
            "Нюрба",
            "Нягань",
            "Нязепетровск",
            "Няндома",
            "Облучье",
            "Обнинск",
            "Обоянь",
            "Обь",
            "Одинцово",
            "Озёрск",
            "Озёрск",
            "Озёры",
            "Октябрьск",
            "Октябрьский",
            "Окуловка",
            "Олёкминск",
            "Оленегорск",
            "Олонец",
            "Омск",
            "Омутнинск",
            "Онега",
            "Опочка",
            "Орёл",
            "Оренбург",
            "Орехово-Зуево",
            "Орлов",
            "Орск",
            "Оса",
            "Осинники",
            "Осташков",
            "Остров",
            "Островной",
            "Острогожск",
            "Отрадное",
            "Отрадный",
            "Оха",
            "Оханск",
            "Очёр",
            "Павлово",
            "Павловск",
            "Павловский Посад",
            "Палласовка",
            "Партизанск",
            "Певек",
            "Пенза",
            "Первомайск",
            "Первоуральск",
            "Перевоз",
            "Пересвет",
            "Переславль-Залесский",
            "Пермь",
            "Пестово",
            "Петров Вал",
            "Петровск",
            "Петровск-Забайкальский",
            "Петрозаводск",
            "Петропавловск-Камчатский",
            "Петухово",
            "Петушки",
            "Печора",
            "Печоры",
            "Пикалёво",
            "Пионерский",
            "Питкяранта",
            "Плавск",
            "Пласт",
            "Плёс",
            "Поворино",
            "Подольск",
            "Подпорожье",
            "Покачи",
            "Покров",
            "Покровск",
            "Полевской",
            "Полесск",
            "Полысаево",
            "Полярные Зори",
            "Полярный",
            "Поронайск",
            "Порхов",
            "Похвистнево",
            "Почеп",
            "Починок",
            "Пошехонье",
            "Правдинск",
            "Приволжск",
            "Приморск",
            "Приморск",
            "Приморско-Ахтарск",
            "Приозерск",
            "Прокопьевск",
            "Пролетарск",
            "Протвино",
            "Прохладный",
            "Псков",
            "Пугачёв",
            "Пудож",
            "Пустошка",
            "Пучеж",
            "Пушкино",
            "Пущино",
            "Пыталово",
            "Пыть-Ях",
            "Пятигорск",
            "Радужный",
            "Радужный",
            "Райчихинск",
            "Раменское",
            "Рассказово",
            "Ревда",
            "Реж",
            "Реутов",
            "Ржев",
            "Родники",
            "Рославль",
            "Россошь",
            "Ростов",
            "Ростов-на-Дону",
            "Рошаль",
            "Ртищево",
            "Рубцовск",
            "Рудня",
            "Руза",
            "Рузаевка",
            "Рыбинск",
            "Рыбное",
            "Рыльск",
            "Ряжск",
            "Рязань",
            "Саки",
            "Салават",
            "Салаир",
            "Салехард",
            "Сальск",
            "Самара",
            "Санкт-Петербург",
            "Саранск",
            "Сарапул",
            "Саратов",
            "Саров",
            "Сасово",
            "Сатка",
            "Сафоново",
            "Саяногорск",
            "Саянск",
            "Светлогорск",
            "Светлоград",
            "Светлый",
            "Светогорск",
            "Свирск",
            "Свободный",
            "Себеж",
            "Севастополь",
            "Северо-Курильск",
            "Северобайкальск",
            "Северодвинск",
            "Североморск",
            "Североуральск",
            "Северск",
            "Севск",
            "Сегежа",
            "Сельцо",
            "Семёнов",
            "Семикаракорск",
            "Семилуки",
            "Сенгилей",
            "Серафимович",
            "Сергач",
            "Сергиев Посад",
            "Сердобск",
            "Серов",
            "Серпухов",
            "Сертолово",
            "Сибай",
            "Сим",
            "Симферополь",
            "Сковородино",
            "Скопин",
            "Славгород",
            "Славск",
            "Славянск-на-Кубани",
            "Сланцы",
            "Слободской",
            "Слюдянка",
            "Смоленск",
            "Снежинск",
            "Снежногорск",
            "Собинка",
            "Советск",
            "Советск",
            "Советск",
            "Советская Гавань",
            "Советский",
            "Сокол",
            "Солигалич",
            "Соликамск",
            "Солнечногорск",
            "Соль-Илецк",
            "Сольвычегодск",
            "Сольцы",
            "Сорочинск",
            "Сорск",
            "Сортавала",
            "Сосенский",
            "Сосновка",
            "Сосновоборск",
            "Сосновый Бор",
            "Сосногорск",
            "Сочи",
            "Спас-Деменск",
            "Спас-Клепики",
            "Спасск",
            "Спасск-Дальний",
            "Спасск-Рязанский",
            "Среднеколымск",
            "Среднеуральск",
            "Сретенск",
            "Ставрополь",
            "Старая Купавна",
            "Старая Русса",
            "Старица",
            "Стародуб",
            "Старый Крым",
            "Старый Оскол",
            "Стерлитамак",
            "Стрежевой",
            "Строитель",
            "Струнино",
            "Ступино",
            "Суворов",
            "Судак",
            "Суджа",
            "Судогда",
            "Суздаль",
            "Сунжа",
            "Суоярви",
            "Сураж",
            "Сургут",
            "Суровикино",
            "Сурск",
            "Сусуман",
            "Сухиничи",
            "Сухой Лог",
            "Сызрань",
            "Сыктывкар",
            "Сысерть",
            "Сычёвка",
            "Сясьстрой",
            "Тавда",
            "Таганрог",
            "Тайга",
            "Тайшет",
            "Талдом",
            "Талица",
            "Тамбов",
            "Тара",
            "Тарко-Сале",
            "Таруса",
            "Татарск",
            "Таштагол",
            "Тверь",
            "Теберда",
            "Тейково",
            "Темников",
            "Темрюк",
            "Терек",
            "Тетюши",
            "Тимашёвск",
            "Тихвин",
            "Тихорецк",
            "Тобольск",
            "Тогучин",
            "Тольятти",
            "Томари",
            "Томмот",
            "Томск",
            "Топки",
            "Торжок",
            "Торопец",
            "Тосно",
            "Тотьма",
            "Трёхгорный",
            "Троицк",
            "Трубчевск",
            "Туапсе",
            "Туймазы",
            "Тула",
            "Тулун",
            "Туран",
            "Туринск",
            "Тутаев",
            "Тында",
            "Тырныауз",
            "Тюкалинск",
            "Тюмень",
            "Уварово",
            "Углегорск",
            "Углич",
            "Удачный",
            "Удомля",
            "Ужур",
            "Узловая",
            "Улан-Удэ",
            "Ульяновск",
            "Унеча",
            "Урай",
            "Урень",
            "Уржум",
            "Урус-Мартан",
            "Урюпинск",
            "Усинск",
            "Усмань",
            "Усолье",
            "Усолье-Сибирское",
            "Уссурийск",
            "Усть-Джегута",
            "Усть-Илимск",
            "Усть-Катав",
            "Усть-Кут",
            "Усть-Лабинск",
            "Устюжна",
            "Уфа",
            "Ухта",
            "Учалы",
            "Уяр",
            "Фатеж",
            "Феодосия",
            "Фокино",
            "Фокино",
            "Фролово",
            "Фрязино",
            "Фурманов",
            "Хабаровск",
            "Хадыженск",
            "Ханты-Мансийск",
            "Харабали",
            "Харовск",
            "Хасавюрт",
            "Хвалынск",
            "Хилок",
            "Химки",
            "Холм",
            "Холмск",
            "Хотьково",
            "Цивильск",
            "Цимлянск",
            "Циолковский",
            "Чадан",
            "Чайковский",
            "Чапаевск",
            "Чаплыгин",
            "Чебаркуль",
            "Чебоксары",
            "Чегем",
            "Чекалин",
            "Челябинск",
            "Чердынь",
            "Черемхово",
            "Черепаново",
            "Череповец",
            "Черкесск",
            "Чёрмоз",
            "Черноголовка",
            "Черногорск",
            "Чернушка",
            "Черняховск",
            "Чехов",
            "Чистополь",
            "Чита",
            "Чкаловск",
            "Чудово",
            "Чулым",
            "Чусовой",
            "Чухлома",
            "Шагонар",
            "Шадринск",
            "Шали",
            "Шарыпово",
            "Шарья",
            "Шатура",
            "Шахты",
            "Шахунья",
            "Шацк",
            "Шебекино",
            "Шелехов",
            "Шенкурск",
            "Шилка",
            "Шимановск",
            "Шиханы",
            "Шлиссельбург",
            "Шумерля",
            "Шумиха",
            "Шуя",
            "Щёкино",
            "Щёлкино",
            "Щёлково",
            "Щигры",
            "Щучье",
            "Электрогорск",
            "Электросталь",
            "Электроугли",
            "Элиста",
            "Энгельс",
            "Эртиль",
            "Югорск",
            "Южа",
            "Южно-Сахалинск",
            "Южно-Сухокумск",
            "Южноуральск",
            "Юрга",
            "Юрьев-Польский",
            "Юрьевец",
            "Юрюзань",
            "Юхнов",
            "Ядрин",
            "Якутск",
            "Ялта",
            "Ялуторовск",
            "Янаул",
            "Яранск",
            "Яровое",
            "Ярославль",
            "Ярцево",
            "Ясногорск",
            "Ясный",
            "Яхрома"});
            this.comboBox1.Location = new System.Drawing.Point(154, 92);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(274, 28);
            this.comboBox1.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 338);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Цвет";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 289);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Год выпуска";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Цена";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Модель";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Марка";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Город";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Фильтр ";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1142, 885);
            this.panel1.TabIndex = 2;
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.SystemColors.Info;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(154, 143);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(274, 28);
            this.comboBox2.TabIndex = 10;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.BackColor = System.Drawing.SystemColors.Info;
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(154, 197);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(274, 28);
            this.comboBox3.TabIndex = 11;
            // 
            // comboBox5
            // 
            this.comboBox5.BackColor = System.Drawing.SystemColors.Info;
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            "Чёрный",
            "Серый",
            "Белый",
            "Серебристый",
            "Синий",
            "Голубой",
            "Зеленый",
            "Бордовый",
            "Красный",
            "Оранжевый",
            "Розовый",
            "Бежевый",
            "Жёлтый",
            "Золотистый",
            "Коричневый",
            "Фиолетовый"});
            this.comboBox5.Location = new System.Drawing.Point(154, 335);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(274, 28);
            this.comboBox5.TabIndex = 25;
            // 
            // comboBox4
            // 
            this.comboBox4.BackColor = System.Drawing.SystemColors.Info;
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "2024",
            "2023",
            "2022",
            "2021",
            "2020",
            "2019",
            "2018",
            "2017",
            "2016",
            "2015",
            "2014",
            "2013",
            "2012",
            "2011",
            "2010",
            "2009",
            "2008",
            "2007",
            "2006",
            "2005",
            "2004",
            "2003",
            "2002",
            "2001",
            "2000",
            "1999",
            "1998",
            "1997",
            "1996",
            "1995",
            "1994",
            "1993",
            "1992",
            "1991",
            "1990",
            "1989",
            "1988",
            "1987",
            "1986",
            "1985",
            "1984",
            "1983",
            "1982",
            "1981",
            "1980",
            "1979",
            "1978",
            "1977",
            "1976",
            "1975",
            "1974",
            "1973",
            "1972",
            "1971",
            "1970",
            "1969",
            "1968",
            "1967",
            "1966",
            "1965",
            "1964",
            "1963",
            "1962",
            "1961",
            "1960",
            "1959",
            "1958",
            "1957"});
            this.comboBox4.Location = new System.Drawing.Point(154, 289);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(274, 28);
            this.comboBox4.TabIndex = 26;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Info;
            this.textBox1.Location = new System.Drawing.Point(154, 241);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(274, 25);
            this.textBox1.TabIndex = 27;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button2.Location = new System.Drawing.Point(780, 253);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 59);
            this.button2.TabIndex = 28;
            this.button2.Text = "Вернуться в меню";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1142, 854);
            this.Controls.Add(this.panel1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Парсер";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSetBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource database1DataSetBindingSource;
        private Database1DataSet database1DataSet;
        private Database1DataSet1 database1DataSet1;
        private System.Windows.Forms.BindingSource autoBindingSource;
        private Database1DataSet1TableAdapters.AutoTableAdapter autoTableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
    }
}