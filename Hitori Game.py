def main():
    import copy
    print("------------ Hitori Oyununa Hoşgeldiniz -------------")
    print()
    print("Oyuna başlamak için B, çıkmak için Ç tuşuna basınız: ", end="")
    giris = input()
    while giris not in ["b", "B", "Ç", "ç"]:
        print("Geçersiz giriş yaptınız.Lütfen tekrar deneyiniz: ", end="")
        giris = input()
    while giris in ["b", "B"]:
        hitori_dosya = open("hitori_bulmaca.txt", "r")
        tablo = []
        satir = hitori_dosya.readline()
        while satir != "":
            sayilar = []
            for i in satir.split():
                sayilar.append(i)
            tablo.append(sayilar)
            satir = hitori_dosya.readline()
        tablo_ciz(tablo)
        tablo_yedek = copy.deepcopy(tablo)
        flag = False
        while not flag:
            print("Satır numarasını ( 1 -", len(tablo), "), sütun numarasını ( 1 -", len(tablo), ") ve işlem kodunu (B:boş, D:dolu, N:normal/işaretsiz) aralarında boşluk bırakarak giriniz:", end="")
            soru = input()
            degerler = {}
            liste = []
            for i in soru.split():
                liste.append(i)
            for i in range(1, 4):
                degerler[i] = liste[i - 1]
            while int(degerler[1]) not in range(1, len(tablo) + 1) or \
                    degerler[3] not in ["B", "b", "D", "d", "N", "n"] or \
                    int(degerler[2]) not in range(1, len(tablo) + 1) or degerler[3]==int() :
                print("Geçersiz giriş yaptınız.Lütfen tekrar deneyiniz: ", end="")
                soru = input()
                degerler = {}
                liste = []
                for i in soru.split():
                    liste.append(i)
                for i in range(1, 4):
                    degerler[i] = liste[i - 1]
            if degerler[3] in ["D", "d"]:
                tablo[int(degerler[1]) - 1][int(degerler[2]) - 1] = "(" + tablo[int(degerler[1]) - 1][int(degerler[2]) - 1] + ")"
            elif degerler[3] in ["B", "b"]:
                tablo[int(degerler[1]) - 1][int(degerler[2]) - 1] = "X"
            elif degerler[3] in ["N", "n"]:
                tablo[int(degerler[1]) - 1][int(degerler[2]) - 1] = tablo_yedek[int(degerler[1]) - 1][int(degerler[2]) - 1]
            tablo_ciz(tablo)
            if kural_1(tablo) and kural_3(tablo) and kural_2(tablo):
                flag = True
                print("*****Tebrikler bulmacayı çözdünüz*****")
        print("Oyuna tekrar başlamak için B, çıkmak için Ç tuşana basınız: ", end="")
        giris = input("")

def tablo_ciz(iki_boyutlu_liste):
    print("    ", end="")
    for i in range(1, len(iki_boyutlu_liste) + 1):
        print(i,end="  ")
    print()
    for row in range(len(iki_boyutlu_liste)):
        print(row + 1, end=" ")
        for column in range(len(iki_boyutlu_liste)):
            print("--", end="")
            print(iki_boyutlu_liste[row][column], end="")
        print("--", end="")
        print()

def kural_1(iki_boyutlu_liste):   # Aynı satır veya sütunda birbirinden farklı sayıların olup olmadığını kontrol eden kural.
    flag1 = True
    flag2 = True
    for i in iki_boyutlu_liste:
        for j in i:
            if j != "X":
                if i.count(j) != 1:
                    flag1 = False
    elemanlar = []
    count = 0
    for z in range(1, len(iki_boyutlu_liste) + 1):
        liste = []
        for i in iki_boyutlu_liste:
            liste.append(i[count])
        elemanlar.append(liste)
        count += 1
    for i in elemanlar:
        for j in i:
            if j != "X":
                if i.count(j) != 1:
                    flag2 = False
    if flag1 and flag2:
        return True
    else:
        return False

def kural_2(iki_boyutlu_liste):  # Boş karelerin birbiri ile yatay yada dikey olarak bağlı olup olmadığını kontrol eden kural.
    flag2 = True
    flag1 = True
    for i in iki_boyutlu_liste:
        for j in i:
            if j == "X":
                if i.index(j) == 0:
                    if i[i.index(j) + 1] == j :
                        flag1 = False
                if i.index(j) == len(i) - 1:
                    if i[i.index(j) - 1] == j:
                        flag1 = False
                if 1 <= i.index(j) <= (len(i) - 2):
                    if i[i.index(j) + 1] == j or i[i.index(j) - 1] == j :
                        flag1 = False
    elemanlar = []
    count = 0
    for z in range(1, len(iki_boyutlu_liste) + 1):
        liste = []
        for i in iki_boyutlu_liste:
            liste.append(i[count])
        elemanlar.append(liste)
        count += 1
    for i in elemanlar:
        for j in i:
            if j == "X":
                if i.index(j) == 0:
                    if i[i.index(j) + 1] == j:
                        flag2 = False
                if i.index(j) == len(i) - 1:
                    if i[i.index(j) - 1] == j:
                        flag2 = False
                if 1 <= i.index(j) <= (len(i) - 2):
                    if i[i.index(j) + 1] == j or i[i.index(j) - 1] == j:
                        flag2 = False
    if flag1 and flag2:
        return True
    else:
        return False

def kural_3(iki_boyutlu_liste):  # Dolu karelerin yatay ve dikey olarak birbirine bağlı olmasını sağlayan kural.
    flag1 = True
    for i in iki_boyutlu_liste:
        for j in i:
            if j != "X":
                if iki_boyutlu_liste.index(i) == 0:
                    if i.index(j) == 0:
                        if i[i.index(j) + 1] == "X" and iki_boyutlu_liste[iki_boyutlu_liste.index(i) + 1][i.index(j)] == "X":
                            flag1 = False
                    if i.index(j) == len(i) - 1:
                        if i[i.index(j) - 1] == "X" and iki_boyutlu_liste[iki_boyutlu_liste.index(i) + 1][i.index(j)] == "X":
                            flag1 = False
                    if 1 <= i.index(j) <= (len(i) - 2):
                        if i[i.index(j)-1] == "X" and i[i.index(j) + 1] == "X" and iki_boyutlu_liste[iki_boyutlu_liste.index(i)+1][i.index(j)] == "X":
                            flag1 = False
                if iki_boyutlu_liste.index(i) == len(iki_boyutlu_liste) - 1:
                    if i.index(j) == 0:
                        if i[i.index(j) + 1] == "X" and iki_boyutlu_liste[iki_boyutlu_liste.index(i) - 1][i.index(j)] == "X":
                            flag1 = False
                    if i.index(j) == len(i) - 1:
                        if i[i.index(j) - 1] == "X" and iki_boyutlu_liste[iki_boyutlu_liste.index(i) - 1][i.index(j)] == "X":
                            flag1 = False
                    if 1 <= i.index(j) <= (len(i) - 2):
                        if i[i.index(j)-1]=="X" and i[i.index(j) + 1] == "X" and iki_boyutlu_liste[iki_boyutlu_liste.index(i)-1][i.index(j)] == "X":
                            flag1 = False
                if i.index(j) == 0:
                    if 1 <= iki_boyutlu_liste.index(i) <= (len(i) - 2):
                        if iki_boyutlu_liste[iki_boyutlu_liste.index(i) - 1][i.index(j)]=="X" and iki_boyutlu_liste[iki_boyutlu_liste.index(i) + 1][i.index(j)] == "X" and iki_boyutlu_liste[iki_boyutlu_liste.index(i)][i.index(j) + 1] == "X":
                            flag1 = False
                if i.index(j) == len(iki_boyutlu_liste) - 1:
                    if 1 <= iki_boyutlu_liste.index(i) <= (len(i) - 2):
                        if iki_boyutlu_liste[iki_boyutlu_liste.index(i) - 1][i.index(j)]=="X" and iki_boyutlu_liste[iki_boyutlu_liste.index(i) + 1][i.index(j)] == "X" and iki_boyutlu_liste[iki_boyutlu_liste.index(i)][i.index(j) - 1] == "X":
                            flag1 = False
                if iki_boyutlu_liste.index(i) in range(1,len(iki_boyutlu_liste) - 1) and i.index(j) in range(1, len(i) - 1):
                    if iki_boyutlu_liste[iki_boyutlu_liste.index(i) - 1][i.index(j)] == "X" and iki_boyutlu_liste[iki_boyutlu_liste.index(i) + 1][i.index(j)] == "X" and iki_boyutlu_liste[iki_boyutlu_liste.index(i)][i.index(j) + 1] == "X" and iki_boyutlu_liste[iki_boyutlu_liste.index(i)][i.index(j) - 1] == "X":
                        flag1 = False
    return flag1

main()




