# HashIt
Logiciel de calcul d'empreinte pour texte et fichier.

<img src="https://pbs.twimg.com/media/Euvn0LvXUAEflbZ?format=png&name=900x900">


### HashIt se base sur les bibliothèques
- hashlib 2.1.0.0 : https://github.com/bonesoul/HashLib
- CryptSharp 2.1.0.0 : https://www.zer7.com/software/cryptsharp
- WinHash : https://github.com/RomelSan/WinHash
- SHA3.Net : https://github.com/griffo-io/sha3.net
- MD5crypt par Poul-Henning Kamp


### Fonctionnalités
- Hash de texte
- Hash de fichier
- Peut utiliser plusieurs algorithmes en une fois
- Prise en charge du salt ($salt . pass, $pass . $salt, $salt . $pass . $salt)
- Prise en charge des itérations (le même algo)
- Export des résultats en CSV


### HashIt gère les algorithmes :
- Blowfish
- LDAP
- LM
- NTLM
- Phpass
- Scrypt
- Keccak_256
- Keccak_512
- SHA3_256
- SHA3_512
- MySQL4
- MySQL5
- MD2
- MD4
- MD5
- MD5Unix
- SHA1
- SHA256
- SHA384
- SHA512
- RIPEMD128
- RIPEMD160
- RIPEMD256
- RIPEMD320
- PBKDF2
- CRC32
- CRC64
- Murmur2
- Murmur3
- Whirlpool
- Haval256
- Tiger2
- Panama
- Gost
- Grindahl512
- HAS160
- RadioGatun64
- Snefru8_256
