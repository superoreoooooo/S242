import numpy as np


"""
s = 2

a = [3, 4, 5]

b = np.array(a)

print(a * s)
print(b * s)

"""

"""
s = 2

v = np.array([3, 6])

print(s + v)
"""

"""
v = np.array([1, 2, 3])
print(v.mean())
"""

"""
v = np.array([[1, 2, 3]]).T
w = np.array([[10, 20]])

print(v + w)
"""

"""
v = np.array([1, 2, 3, 7, 8, 9])
v_dim = len(v)
v_mag = np.linalg.norm(v)

print(v_dim, v_mag)
"""

"""
w = np.array([1, 2, 3])
s = np.linalg.norm(w)
w = w/s

print(w, s, np.linalg.norm(w))
"""

"""

a = np.array([5, 4, 8, 2])
b = np.array([1, 0, .5, -1])

print(a*b)
"""

"""
a = np.array([[1, 1]])

print(np.sqrt(a[0][0] * a[0][0] + a[0][1] * a[0][1]))
"""

"""
norm = 0

for i in range(0, len(a), 1) :
    norm += a[i]

print(np.sqrt(norm))
"""

"""
w = np.array([1, 1])
s = np.linalg.norm(w)

w = w / s

print(w)
"""

a = np.array([[1, 2, 3]]).T
b = np.array([[4, 5, 6]])

print(np.dot(a, b), np.linalg.norm(np.dot(a, b)))