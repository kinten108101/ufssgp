#include "iostream"
using namespace std;

void Input(int a[],int &n)
{
cout << "Nhap n: "; cin >> n;
for (int i(0); i < n; i++)
{
cout << "Gia tri thu " << i + 1 << " la: "; cin >> a[i];
}
}
void Output(int a[], int n)
{
for (int i(0); i < n; i++)
{
cout << a[i]<<" ";
}
}
int MaxLocation(int a[], int n)
{

int maximum = a[0], location;
for (int i = 1; i a[i])
{
maximum = a[i];
location = i;
}
return location;
}
void swapvalue(int &x, int &y)
{
int temp = x;
x = y;
y = temp;
}
int SumMax(int a[], int n)
{
int a1[20], a2[20], n1(0), n2(0), sum(0);
for (int i(0); i < n; i++)
{
if (i % 2 == 0)
{
a1[i / 2] = a[i];
n1++;
}
else
{
a2[i / 2] = a[i];
n2++;
}
}
int MinPosition = MinLocation(a1, n1);
int MaxPosition = MaxLocation(a2, n2);
swapvalue(a1[MinPosition], a2[MaxPosition]);
for (int i(0); i < n1; i++) sum += a1[i];
for (int i(0); i < n2; i++) sum -= a2[i];
return sum;
}
int main()
{
int myarray[100000], n;
Input(myarray,n);
cout << "\n" << SumMax(myarray, n)<<endl;
return 0;
}