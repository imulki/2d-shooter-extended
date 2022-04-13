# IF3210-2022-Unity-29

Tugas Besar Unity, IF3210 Pengembangan Aplikasi pada Platform Khusus

## Deskripsi Aplikasi

Dalam tugas besar kali ini, mahasiswa diminta untuk membangun sebuah game pada platform Unity. Game tersebut bernama Survival Shooter: Extended yang merupakan game ekstensi Survival Shooter dari Unity Learn.

## Cara kerja

### Atribut
Pemain memiliki atribut power, speed, dan health. Power terpaut pada script shooting, speed pada movement, dan health pada health.
Nilai ketiga atribut tersebut ditampilkan di pojok kiri bawah layar dengan simbol yang sesuai.
### Orbs
Ketiga atribut diatas dapat ditingkatkan dengan mengambil orb yang ter-spawn secara acak dalam peta. Orb hijau untuk health, merah untuk power, dan kuning untuk speed.
### Mobs
Terdapat 3 mob tambahan:
1. Skeleton: Bergerak dengan lambat (hingga terlihat tidak bergerak) dan menembakkan proyektil.
2. Bomber: Bergerak dengan cepat untuk meledakkan dirinya, jarak ledakan terlihat dengan linkaran merah dibawahnya.
3. Boss: Hellephant yang bermutasi menjadi lebih besar, cepat, dan kuat.
### Game Modes
Terdapat 2 game modes:
1. Zen mode: Bertahan selama mungkin, musuh di-spawn secara acak, skor didapatkan dari bertahan lebih lama.
2. Wave mode: Bertahan melawan musuh yang datang secara periodik. Setiap wave akan semakin sulit dengan setiap 3 wave memunculkan boss.
### Weapon Upgrades
Terdapat 2 weapon upgrades:
1. Diagonal weapon menambahkan tembakan pada kanan dan kiri, batasnya adalah 5 tembakan sekaligus.
2. Faster weapon mempercepat rate of fire senjata.
Pada zen mode, upgrade didapatkan setelah bertahan selama beberapa waktu, sedangkan pada wave mode didapatkan setiap akhir wave.
### Scoreboard
Scoreboard menampilkan nama dan skor pemain terurut dari yang terbaik untuk kedua game modes. Scoreboard dapat diakses di main menu.
### Main Menu
Menjadi tampilan pertama. Terdapat pilihan untuk keluar game (hanya bekerja setelah game nya di-build), melihat scoreboard, dan main. Jika memilih main, ditampilkan 2 pilihan mode (dan 1 pilihan rahasia). Setelah memilih mode, pemain memasukkan nama sebelum mulai bermain.
### Bonus
1. Mode first person shooter di peta rahasia dapat diakses melalui pilihan rahasia pada tampilan pilihan mode.
2. Beberapa kebijakan desain:
- Animasi transisi scene
- Tampilan main menu
- Balance dari game mode
- Tampilan musuh dan serangannya (untuk mob baru)
- Pemberian lampu untuk player
- Tampilan UI
- Dsb.

## Library

1. TextMeshPro: Supaya beberapa teks ter-render dengan lebih baik
2. Unity Particle Pack: Memberikan efek ledakan pada musuh bomber
3. 2D Weapon Pack: Untuk sprite senjata pada UI

## Screenshots

<img src="/Screenshots/MainMenu.png" style="max-width: 120px">

<img src="/Screenshots/GameModes.png" style="max-width: 120px">

<img src="/Screenshots/Game1.png" style="max-width: 120px">

<img src="/Screenshots/FPS.png" style="max-width: 120px">

## Pembagian kerja

### Mahameru Ds
1. Orbs mechanic
2. Faster weapon
3. Zen scaling difficulty
### Ilyasa Salafi Putra Jamal
1. Main Menu
2. Scoreboard
3. Mobs
4. Tampilan atribut
5. First person mode
6. New secret map
### Imam Nurul Hukmi
1. Game modes
2. Game over screen
3. Diagonal weapon

