import numpy as np

""" #아다마르곱

a = np.array([5, 4, 8, 2])
b = np.array([1, 0, .5, -1])

print(a * b)

"""

""" #외적

v = np.array([[1, 2, 3, 4]])
w = np.array([[1, 2, 3, 4]]).T

print(np.outer(v, w))

"""

"""

#print(np.array([[1, 2, 3,4]]).shape)

v = np.array([3, 1])
w = np.array([1, 2])

def getHorizontal(t, r) :
    return (t.dot(r) / t.dot(t)) * t

def getVertical(t, r) :
    return r - getHorizontal(t, r)


print(getHorizontal(v, w))
print(getVertical(v, w))
print(getVertical(v, w) + getHorizontal(v, w))

print(v.dot(getVertical(v, w)))
"""

t = np.array([3, 4])
r = np.array([1, 2])

def para(t, r) :
    return r * (t.dot(r) / r.dot(r))

def orth(t, para) :
    return t - para

print(orth(t, para(t, r)))

print(np.isclose(para(t, r).dot(orth(t, para(t, r))), 0))