using namespace std;
#include <iostream>
#include <string.h>
#include <string>
//Khai báo cấu trúc dNode
typedef struct Date
{
	int day, month, year;
}DATE;
bool CheckNamNhuan(Date x)
{
	if (x.year % 400 == 0 || (x.year % 4 == 0 && x.year % 100 != 0))
	{
		return true;
	}
	return false;
}
bool CheckDate(DATE x)
{
	int temp = x.month;
	switch (temp)
	{
	case 1: case 3: case 5: case 7: case 8: case 10: case 12:
		if (x.day >= 1 && x.day <= 31)
		{
			return true;
		}
		break;
	case 4: case 6: case 9: case 11:
		if (x.day >= 1 && x.day <= 30)
		{
			return true;
		}
		break;
	case 2:
		if ((CheckNamNhuan(x) == true && (x.day >= 1 && x.day <= 29)) || (CheckNamNhuan(x) == false && (x.day >= 1 && x.day <= 28)))
		{
			return true;
		}
		break;
	default:
		break;
	}
	return false;
}
void NhapDate(DATE& x)
{
	fflush(stdin);
	cout << "Nhap ngay: ";
	cin >> x.day;
	cout << "Nhap thang: ";
	cin >> x.month;
	cout << "Nhap nam: ";
	cin >> x.year;
	while (CheckDate(x) == false)
	{
		cout << "Nhap sai, moi nhap lai: ";
		fflush(stdin);
		cin >> x.day >> x.month >> x.year;
	}
}
typedef struct SanPham
{
	string ten;
	int maSP;
	DATE ngayXuatKho;
}SP;
typedef struct Node
{
	SP Info;
	Node* pPrev;	//trỏ đến phần tử đứng trước
	Node* pNext;	//trỏ đến phần tử đứng sau
} NODE;
typedef struct List
{
	NODE* pHead;		//trỏ đến phần tử đầu DS
	NODE* pTail;		//trỏ đến phần tử cuối DS
}LIST;
void InitList(LIST& l)
{
	l.pHead = l.pTail = NULL;
}
int IsEmptyList(LIST l)
{
	if (l.pHead == NULL)
		return 1; //rong
	return 0;
}
int SizeOfList(LIST l)
{
	Node* pTemp = l.pHead;
	int size = 0;
	while (pTemp != NULL)
	{
		pTemp = pTemp->pNext;
		size++;
	}
	return size;
}
NODE* GetNewNode(SP x) //Đưa giá trị Info vào trong node
{
	NODE* p; // cấp phát vùng nhớ cho phần tử
	p = new NODE;
	if (p == NULL)
	{
		cout << "Khong du bo nho";
		exit(1);
	}
	p->Info = x;
	p->pPrev = NULL;
	p->pNext = NULL;
	return p;
}
void ThemVaoDau(LIST& l, NODE* p)
{
	if (IsEmptyList(l) == 1)
	{
		l.pHead = l.pTail = p;
		//l.pTail = l.pHead;
	}
	else {
		p->pNext = l.pHead;
		l.pHead->pPrev = p;
		l.pHead = p;
	}
}
void ThemVaoCuoi(LIST& l, NODE* p)
{
	if (l.pHead == NULL)
	{
		l.pHead = p;
		l.pTail = l.pHead;
	}
	else {
		l.pTail->pNext = p;
		p->pPrev = l.pTail;
		l.pTail = p;
	}
}
void ThemSauQ(LIST& l, NODE* q, int pos)
{
	if (pos == SizeOfList(l) - 1)
		ThemVaoCuoi(l, q);
	else
	{
		Node* pTemp = GetNewNode(q->Info);
		Node* pInsert = l.pHead;
		int i = 0;
		while (pInsert != NULL)
		{
			if (i == pos)
			{
				break;
			}
			pInsert = pInsert->pNext;
			i++;
		}
		pTemp->pNext = pInsert->pNext;
		pTemp->pPrev = pInsert;
		pInsert->pNext->pPrev = pTemp;
		pInsert->pNext = pTemp;
	}
}
void ThemGiaTri(LIST& l, SP value, bool last)
{
	NODE* p = GetNewNode(value);
	if (last == true)
	{
		ThemVaoCuoi(l, p);
	}
	else ThemVaoDau(l, p);
}

void NhapSanPham(SP& x)
{
	cout << "Ten: ";
	cin.ignore(1, 1);
	getline(cin, x.ten);
	cout << "Ma SP: ";
	cin >> x.maSP;
	cout << "ngay xuat kho\n";
	NhapDate(x.ngayXuatKho);
}

void NhapDS(LIST& l, bool last)
{
	int n;
	try
	{
		cout << "Nhap n: ";
		cin >> n;
	}
	catch (exception)
	{
		cout << "Nhap so nguyen: ";
		cin >> n;
	}
	for (int i = 0; i < n; i++)
	{
		SP a;
		NhapSanPham(a);
		ThemGiaTri(l, a, true);
	}
}
void XuatDate(DATE x)
{
	cout << x.day << "/" << x.month << "/" << x.year << "\n";
}
void XuatSanPham(SP x)
{
	cout << "Ten: " << x.ten << "\n";
	cout << "Ma san pham: " << x.maSP << "\n";
	cout << "Ngay xuat kho: ";
	XuatDate(x.ngayXuatKho);
	cout << "\n";
}
void XuatDS(LIST l) //in xuoi
{
	NODE* p = l.pHead;
	cout << "\n===================== Danh Sach =====================\n";
	while (p != NULL)
	{
		XuatSanPham(p->Info);
		cout << "\n";
		p = p->pNext;
	}
}
void XoaDau(LIST& l)
{
	NODE* p;
	if (l.pHead != NULL)
	{
		p = l.pHead;
		l.pHead = l.pHead->pNext;
		l.pHead->pPrev = NULL;
		delete p;
		if (l.pHead == NULL)
			l.pTail = NULL;
		//else l.pHead->pPrev = NULL;
	}
	else {
		cout << "Danh sach rong";
		return;
	}
}
void XoaCuoi(LIST& l)
{
	NODE* p;
	if (l.pTail != NULL)
	{
		p = l.pTail;
		l.pTail = l.pTail->pPrev;
		l.pTail->pNext = NULL;
		delete p;
		if (l.pHead == NULL)
			l.pTail = NULL;
		//else l.pHead->pPrev = NULL;
	}
	else {
		cout << "Danh sach rong";
		return;
	}
}
NODE* XoaSauQ(LIST& l, int pos)
{
	/*if (pos == SizeOfList(l) - 2)
	{
		XoaCuoi(l);
	}
	else
	{
		int i = 0;
		Node* pRemove = l.pHead;
		Node* pPre_Remove = NULL;
		if (pRemove == NULL)
		{
			printf("Danh sach rong!\n");
			return;
		}
		while (pRemove != NULL)
		{
			pPre_Remove = pRemove;
			pRemove = pRemove->pNext;
			if (i == pos)
			{
				break;
			}
			i++;
		}
		pPre_Remove->pNext = pRemove->pNext;
		pRemove->pNext->pPrev = pPre_Remove;
		pRemove->pPrev = NULL;
		pRemove->pNext = NULL;
		delete pRemove;
		pRemove = NULL;
	}*/
	if (l.pHead == NULL)
		return l.pHead;
	if (pos == -1)
	{
		if (l.pHead->pNext != NULL) 
			l.pHead->pPrev = NULL;
		return l.pHead->pNext;
	}
	NODE* node = l.pHead;
	while (node!=NULL && pos>-1)
	{
		node = node->pNext;
		pos--;
	}
	if (node == NULL)
	{
		cout << "Element doesn't exists at given position";
		return l.pHead;
	}
	if (node->pNext != NULL)
		node->pNext->pPrev = node->pPrev;
	node->pPrev->pNext = node->pNext;
	return l.pHead;
}
NODE* XoaGiaTri(LIST& l, int data)
{
	if (l.pHead == NULL)
		return l.pHead;
	if (l.pHead->Info.maSP == data)
	{
		if (l.pHead->pNext != NULL)
			l.pHead->pNext->pPrev = NULL;
		return l.pHead->pNext;
	}
	NODE* node = l.pHead;
	while (node != NULL)
	{
		if (node->Info.maSP == data)
			break;
		node = node->pNext;
	}
	if (node == NULL)
	{
		cout << "Element doesn't exists int list";
		return l.pHead;
	}
	if (node->pNext != NULL)
		node->pNext->pPrev = node->pPrev;
	node->pPrev->pNext = node->pNext;
	return l.pHead;
}
int SearchingString(NODE* head, string x)
{
	NODE* p = head;
	int pos = 0;
	while (p->Info.ten.compare(x) != 0 && p->pNext != NULL)
	{
		pos++;
		p = p->pNext;
	}
	if (p->Info.ten.compare(x) != 0)
		return -1;
	return (pos + 1);
}
int SearchingInt(LIST l, int x)
{
	NODE* p = l.pHead;
	int pos = 0;
	int dem = 0;
	while (p != NULL)
	{
		if (p->Info.maSP == x)
		{
			return (pos + 1);
		}
		p = p->pNext;
		pos++;
	}
	if (dem == 0)
		return -1;
}
void SearchNode(LIST l, int x)
{
	int searchNode = SearchingInt(l, x);
	if (searchNode == -1)
		cout << "Khong ton tai" << "\n";
	else cout << "Gia tri o vi tri: " << searchNode;
}
LIST SearchNodesTheoTen(LIST l, string x)
{
	NODE* temp = l.pHead;
	LIST result;
	InitList(result);
	while (temp != NULL)
	{
		if (SearchingString(temp, x) != -1)
			ThemGiaTri(result, temp->Info, true);
		temp = temp->pNext;
	}
	return result;
}
void SelectionSort(LIST& l)
{
	NODE* temp = l.pHead;
	while (temp != NULL)
	{
		NODE* min = temp;
		NODE* r = temp->pNext;
		while (r != NULL)
		{
			//min.data.MaSP > r.data.MaSP
			if (min->Info.ten.compare(r->Info.ten) > 0)
				min = r;

			r = r->pNext;
		}
		SP x = temp->Info;
		temp->Info = min->Info;
		min->Info = x;
		temp = temp->pNext;
	}
}

void QuickSort(LIST& myList)
{
	//Truong hop danh sach rong hoac co 1 phan tu
	if (myList.pHead == myList.pTail)
	{
		//printf("\nDanh sach co it hon 2 Employee nen khong the sap xep\n");
		return;
	}
	else
	{
		LIST myList1;
		LIST myList2;
		Node* pivot;
		Node* p;
		InitList(myList1);
		InitList(myList2);
		pivot = myList.pHead; 
		p = myList.pHead->pNext;
		while (p != NULL)
		{
			Node* q = p;
			p = p->pNext;
			q->pNext = NULL;
			if (q->Info.maSP < pivot->Info.maSP)
			{
				ThemGiaTri(myList1, q->Info, true);
			}
			else
			{
				ThemGiaTri(myList2, q->Info, true);
			}
		};
		//Goi de quy sap xep cho cac danh sach con
		QuickSort(myList1);
		QuickSort(myList2);
		//Ghep noi danh sach 1 + pivot
		if (!IsEmptyList(myList1))
		{
			myList.pHead = myList1.pHead;
			myList1.pTail->pNext = pivot;
		}
		else
		{
			myList.pHead = pivot;
		}
		//Ghep noi pivot + danh sach 2
		pivot->pNext = myList2.pHead;
		if (!IsEmptyList(myList2))
		{
			myList.pTail = myList2.pTail;
		}
		else
		{
			myList.pTail = pivot;
		}
	}
}
void combine(LIST& l1)
{
	LIST l2;
	InitList(l2);
	NhapDS(l2, true);
	NODE* p = l2.pHead;
	while (p != NULL)
	{
		ThemVaoCuoi(l1, p);
		p = p->pNext;
	}
}
void removeMaSPSatisfy(LIST& l, int maSP)
{
	NODE* temp = l.pHead;
	//int i = -1;
	while (temp != NULL)
	{
		//i++;
		if (temp->Info.maSP == maSP)
		{
			//XoaSauQ(l, i);
			/*XoaGiaTri(l, 3);*/
			l.pHead = XoaGiaTri(l, maSP);
		}
		temp = temp->pNext;
	}
}

bool KiemTraNgay(DATE d1, DATE d2)
{
	if (d2.year > d1.year)
		return true;
	else if (d2.year == d1.year)
	{
		if (d2.month > d1.month)
			return true;
		else if (d2.month == d1.month)
		{
			if (d2.day > d1.day)
				return true;
		}
	}
	return false;
}
LIST DSSPSauNgayXuatKho(LIST l, DATE date, LIST& result)
{
	NODE* temp = l.pHead;
	while (temp != NULL)
	{
		if (KiemTraNgay(date, temp->Info.ngayXuatKho) == true)
		{
			ThemGiaTri(result, temp->Info, true);
		}
		temp = temp->pNext;
	}
	return result;
}
// Function to find the nodes
// which have to be swapped
int Menu()
{
	cout << "\n|================================== QUAN LY SAN PHAM CUA CUA HANG =========================================|\n";
	cout << "|                                                                                                          |\n";
	cout << "|                        1. Nhap Danh Sach                                                                 |\n";
	cout << "|                        2. Xuat Danh Sach                                                                 |\n";
	cout << "|                        3. Chen Them San Pham Vao Dau Danh Sach                                           |\n";
	cout << "|                        4. Chen Them San Pham Vao Cuoi Danh Sach                                          |\n";
	cout << "|                        5. Chen Them San Pham Vao Sau 1 Vi Tri Bat Ky                                     |\n";
	cout << "|                        6. Xoa San Pham O Vi Tri Dau Danh Sach                                            |\n";
	cout << "|                        7. Xoa San Pham O Vi Tri Cuoi Danh Sach                                           |\n";
	cout << "|                        8. Xoa San Pham O Sau 1 Vi Tri Bat Ky                                             |\n";
	cout << "|                        9. Tim 1 San Pham Theo Ma SP                                                      |\n";
	cout << "|                        10. Xuat Danh Sach San Pham Cung Ten                                              |\n";
	cout << "|                        11. Sap Xep Danh Sach San Pham Theo Alphabet (Selection Sort)                     |\n";
	cout << "|                        12. Sap Xep Danh Sach San Pham Theo Ma SP (Quick Sort)                            |\n";
	cout << "|                        13. Gop 2 Danh Sach                                                               |\n";
	cout << "|                        14. Lay Danh Sach San Pham Da Xuat Kho Theo Ngay Da Nhap                          |\n";
	cout << "|                        15. Xoa Tat Ca San Pham Tu Ma SP Da Nhap                                          |\n";
	cout << "|                                                                                                          |\n";
	cout << "============================================================================================================\n";
	cout << "\nBan chon:  ";
	int choose;
	do {
		cout << "\nNhap so nguyen tu 1-15: \n";
		cin >> choose;
		if (choose < 1 || choose > 15)
			cout << "\nNhap sai, moi nhap lai: \n";
	} while (choose < 1 || choose > 15);
	return choose;
}
int main()
{
	LIST a;

	InitList(a);
	NODE* insert3;
	SP inserSPAtStart;
	SP inserSPAtLast;
	NODE* insert4;
	SP insertAfterQ;
	NODE* insert5;
	string ten10;
	int sizeSearchNodes10;
	LIST searchNode10;
	InitList(searchNode10);
	DATE date14;
	LIST DSSPXK14;
	InitList(DSSPXK14);
	int maHang15;
	
	while (true)
	{
		int choose = Menu();
		switch (choose)
		{
		case 1:
			cout << "\n1.Nhap Danh Sach\n";
			NhapDS(a, true);
			break;
		case 2:
			cout << "\n2. Xuat Danh Sach\n";
			XuatDS(a);
			break;
		case 3:
			cout << "\n3. Chen Them San Pham Vao Dau Danh Sach\n";
			NhapSanPham(inserSPAtStart);
			insert3 = GetNewNode(inserSPAtStart);
			ThemVaoDau(a, insert3);
			break;
		case 4:
			cout << "\n4. Chen Them San Pham Vao Cuoi Danh Sach\n";
			NhapSanPham(inserSPAtLast);
			insert4 = GetNewNode(inserSPAtLast);
			ThemVaoCuoi(a, insert4);
			break;
		case 5:
			cout << "\n5. Chen Them San Pham Vao Sau 1 Vi Tri Bat Ky\n";
			int pos5;
			do {
				cout << "\nNhap vi tri muon chen sau no: \n";
				cin >> pos5;
				if (pos5 < 0 || pos5 >= SizeOfList(a))
					cout << "\nNhap vi tri sai, moi nhap lai: \n";
			} while (pos5 < 0 || pos5 >= SizeOfList(a));
			NhapSanPham(insertAfterQ);
			insert5 = GetNewNode(insertAfterQ);
			ThemSauQ(a, insert5, pos5);
			break;
		case 6:
			cout << "\n6. Xoa San Pham O Vi Tri Dau Danh Sach\n";
			XoaDau(a);
			break;
		case 7:
			cout << "\n7. Xoa San Pham O Vi Tri Cuoi Danh Sach\n";
			XoaCuoi(a);
			break;
		case 8:
			cout << "\n8. Xoa San Pham O Sau 1 Vi Tri Bat Ky\n";
			int pos8;
			do {
				cout << "\nNhap vi tri muon xoa sau no: \n";
				cin >> pos8;
				if (pos8 < -1 || pos8 > SizeOfList(a) - 2)
					cout << "\nNhap vi tri sai, moi nhap lai: \n";
			} while (pos8 < -1 || pos8 > SizeOfList(a) - 2);
			XoaSauQ(a, pos8);
			break;
		case 9:
			cout << "\n9. Tim 1 San Pham Theo Ma SP\n";
			int maSP9;
			cout << "Nhap ma san pham can tim:";
			cin >> maSP9;
			SearchNode(a, maSP9);
			break;
		case 10:
			cout << "\n10. Xuat Danh Sach San Pham Cung Ten\n";
			cout << "Nhap ten hang: ";
			cin.ignore(1, 1);
			getline(cin, ten10);
			searchNode10 = SearchNodesTheoTen(a, ten10);
			sizeSearchNodes10 = SizeOfList(searchNode10);
			if (sizeSearchNodes10 == 0)
				cout << "Khong co san pham cung ten";
			else
			{
				XuatDS(searchNode10);
			}
			break;
		case 11:
			cout << "\n11. Sap Xep Danh Sach San Pham Theo Alphabet (Selection Sort)\n";
			SelectionSort(a);
			break;
		case 12:
			cout << "\n12. Sap Xep Danh Sach San Pham Theo Ma Hang (Quick Sort)\n";
			QuickSort(a);
			break;
		case 13:
			cout << "\n13. Gop 2 Danh Sach\n";
			combine(a);
			XuatDS(a);
			break;
		case 14:
			cout << "\n14. Xuat Danh Sach San Pham Da Xuat Kho Theo Ngay Da Nhap\n";
			NhapDate(date14);
			DSSPXK14 = DSSPSauNgayXuatKho(a, date14, DSSPXK14);
			XuatDS(DSSPXK14);
			break;
		case 15:
			cout << "\n15. Xoa Tat Ca San Pham Tu Ma Hang Da Nhap\n";
			cout << "Nhap ma san pham muon xoa: ";
			cin >> maHang15;
			removeMaSPSatisfy(a, maHang15);
			XuatDS(a);
			break;
		default:
			break;
		}
	}
}
