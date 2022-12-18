export const balanced = (s: string): boolean => {
  if (s === "" || s.length === 1 || s.length === 2 || allWildcards(s)) {
    return true;
  }

  if (s.length > 500000) {
    return false;
  }

  const hasWildcards = s.includes("*");
  const uniqueChars = countUniqueChars(s.split("*").join("")); //try .replaceAll
  const charCounts: { [char: string]: number } = {};
  let maxCount = 0;

  for (const char of s) {
    charCounts[char] = (charCounts[char] || 0) + 1;
  }

  for (const char in charCounts) {
    if (char !== "*" && charCounts[char] > maxCount) {
      maxCount = charCounts[char];
    }
  }

  if (hasWildcards) {
    for (const char in charCounts) {
      if (char !== "*" && charCounts[char] !== maxCount) {
        if (charCounts[char] < maxCount) {
          const wildcardsNeeded = maxCount - charCounts[char];

          if (charCounts["*"] < wildcardsNeeded) {
            return false;
          }

          charCounts["*"] -= wildcardsNeeded;
          charCounts[char] += wildcardsNeeded;
        }
      }
    }
  } else {
    for (const char in charCounts) {
      if (charCounts[char] !== maxCount) {
        return false;
      }
    }
  }

  let wildcardsRemaining = charCounts["*"];
  let availableChars = 52 - uniqueChars;

  if (hasWildcards && wildcardsRemaining !== 0) {
    if (wildcardsRemaining >= maxCount) {
      const fits = Number.isInteger(wildcardsRemaining / uniqueChars);

      if (fits) {
        return true;
      } else if (!fits) {
        //Edgecase scenarios
        const canStillBeDistributed = wildcardsRemaining - uniqueChars;

        if (canStillBeDistributed > 0) {
          for (const char in charCounts) {
            if (char !== "*") {
              charCounts[char]++;
              charCounts["*"]--;
            }
          }

          maxCount++;
          wildcardsRemaining = charCounts["*"];

          if (
            wildcardsRemaining % 2 === 0 &&
            wildcardsRemaining / 2 === maxCount
          ) {
            return true;
          }

          if (wildcardsRemaining === maxCount && availableChars === maxCount) {
            return true;
          }
        }
        //End of edgecase scenarios

        if (wildcardsRemaining === maxCount && uniqueChars !== 52) {
          return true;
        } else {
          return false;
        }
      }
    } else {
      return false;
    }
  }

  if (charCounts[""] < maxCount && charCounts[""] > 0) {
    return false;
  }

  return true;
};

const allWildcards = (s: string): boolean => {
  let n = s.length;
  for (let i = 1; i < n; i++) if (s[i] !== s[0]) return false;

  return true;
};

const countUniqueChars = (s: string): number => {
  const charSet = new Set();

  for (let i = 0; i < s.length; i++) {
    charSet.add(s[i]);
  }
  return charSet.size;
};
